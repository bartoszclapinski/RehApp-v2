using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehApp.Application.Organization.Commands.CreateOrganization;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;
using DomainVisit = RehApp.Domain.Entities.Visits.Visit;

namespace RehApp.Application.Visit.Commands.CreateVisit;

public class CreateVisitCommandHandler(
	IVisitRepository visitRepository,
	IOrganizationRepository organizationRepository,
	IPatientRepository patientRepository,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<CreateVisitCommand, Guid>
{

	public async Task<Guid> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
	{
		var patient = await patientRepository.GetByIdAsync(request.PatientId);
		if (patient is null) throw new Exception("Patient not found");
		
		var organizationId = patient.OrganizationId;
		var organization = await organizationRepository.GetByIdAsync(organizationId);
		if (organization is null) throw new Exception("Organization not found");
		
		var user = await userManager.Users
			.FirstOrDefaultAsync(u => u.Id == request.CreatedByUserId, cancellationToken);
		if (user is null) throw new Exception("User not found");

		var visit = mapper.Map<DomainVisit>(request);
		await visitRepository.AddAsync(visit);

		return visit.Id;
	}
}
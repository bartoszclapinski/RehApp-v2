using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RehApp.Application.DTOs;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Patient.Queries.GetPatientsForOrganization;

public class GetPatientsForOrganizationQueryHandler(
	IPatientRepository patientRepository,
	IMapper mapper) : IRequestHandler<GetPatientsForOrganizationQuery, List<PatientDto>>
{
	public async Task<List<PatientDto>> Handle(GetPatientsForOrganizationQuery request, CancellationToken cancellationToken)
	{
		var patients = await patientRepository.GetPatientsByOrganizationIdAsync(request.OrganizationId);
		return patients.Select(patient => mapper.Map<PatientDto>(patient)).ToList();
	}
}
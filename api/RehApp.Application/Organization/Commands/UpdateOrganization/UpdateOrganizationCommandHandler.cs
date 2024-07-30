using AutoMapper;
using MediatR;
using RehApp.Application.DTOs;
using RehApp.Domain.Interfaces;
using DomainOrganization = RehApp.Domain.Entities.Organizations.Organization;

namespace RehApp.Application.Organization.Commands.UpdateOrganization;

public class UpdateOrganizationCommandHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper): IRequestHandler<UpdateOrganizationCommand>
{

	public async Task Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
	{
		DomainOrganization? organization = await organizationRepository.GetByIdAsync(request.Id);
		if (organization is null) throw new Exception("Organization not found");

		mapper.Map(request, organization);
		await organizationRepository.SaveChangesAsync();
	}
}
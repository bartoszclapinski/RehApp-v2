using AutoMapper;
using MediatR;
using RehApp.Domain.Interfaces;
using DomainOrganization = RehApp.Domain.Entities.Organizations.Organization;

namespace RehApp.Application.Organization.Commands.CreateOrganization;

public class CreateOrganizationCommandHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<CreateOrganizationCommand, Guid>
{

	public async Task<Guid> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
	{
		var organization = mapper.Map<DomainOrganization>(request);
		DomainOrganization result = await organizationRepository.AddAsync(organization);
		return result.Id;
	}
}
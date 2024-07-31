using AutoMapper;
using MediatR;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Organization.Commands.CreateOrganization;

public class CreateOrganizationCommandHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<CreateOrganizationCommand, Guid>
{
	public async Task<Guid> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
	{
		var organization = mapper.Map<Domain.Entities.Organizations.Organization>(request);
		await organizationRepository.AddAsync(organization);
		return organization.Id;
	}
}
using AutoMapper;
using MediatR;
using RehApp.Application.DTOs;
using RehApp.Domain.Interfaces;
using DomainOrganization = RehApp.Domain.Entities.Organizations.Organization;

namespace RehApp.Application.Organization.Queries.GetOrganizationById;

public class GetOrganizationByIdQueryHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<GetOrganizationByIdQuery, OrganizationDto>
{

	public async Task<OrganizationDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
	{
		DomainOrganization? organization = await organizationRepository.GetByIdAsync(request.OrganizationId);
		if (organization is null) throw new Exception("Organization not found");

		return mapper.Map<OrganizationDto>(organization);
	}
}
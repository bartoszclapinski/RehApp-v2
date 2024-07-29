using AutoMapper;
using MediatR;
using RehApp.Application.DTOs;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Organization.Queries.GetAllOrganizations;

public class GetAllOrganizationsQueryHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<GetAllOrganizationsQuery, IEnumerable<OrganizationDto>>
{

	public async Task<IEnumerable<OrganizationDto>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken)
	{
		var organizations = await organizationRepository.GetAllAsync();
		return mapper.Map<IEnumerable<OrganizationDto>>(organizations);
	}
}
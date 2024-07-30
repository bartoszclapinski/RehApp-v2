using AutoMapper;
using MediatR;
using RehApp.Application.DTOs;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Organization.Queries.GetAllOrganizationsForUserId;

public class GetAllOrganizationsForUserIdQueryHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<GetAllOrganizationsForUserIdQuery, IEnumerable<OrganizationDto>>
{

	public async Task<IEnumerable<OrganizationDto>> Handle(GetAllOrganizationsForUserIdQuery request, CancellationToken cancellationToken)
	{
		var organizations = await organizationRepository.GetByUserIdAsync(request.UserId);
		return mapper.Map<IEnumerable<OrganizationDto>>(organizations);
	}
}
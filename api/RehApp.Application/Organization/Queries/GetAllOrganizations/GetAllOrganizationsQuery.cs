using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Queries.GetAllOrganizations;

public class GetAllOrganizationsQuery : IRequest<IEnumerable<OrganizationDto>>
{
	
}
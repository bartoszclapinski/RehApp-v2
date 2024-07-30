using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Queries.GetAllOrganizationsForUserId;

public class GetAllOrganizationsForUserIdQuery(string userId) : IRequest<IEnumerable<OrganizationDto>>
{
	public string UserId { get; set; } = userId;
}
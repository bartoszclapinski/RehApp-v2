using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.User.Queries.GetUsersForOrganization;

public class GetUsersForOrganizationQuery : IRequest<IEnumerable<BaseUserDto>>
{
	public Guid OrganizationId { get; set; }
}
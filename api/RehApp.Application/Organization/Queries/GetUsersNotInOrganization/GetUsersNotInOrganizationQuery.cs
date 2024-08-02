using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Queries.GetUsersNotInOrganization;

public class GetUsersNotInOrganizationQuery : IRequest<IEnumerable<BaseUserDto>>
{
	public Guid OrganizationId { get; set; }
}
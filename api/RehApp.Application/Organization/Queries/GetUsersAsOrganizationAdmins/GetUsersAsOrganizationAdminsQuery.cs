using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Queries.GetUsersAsOrganizationAdmins;

public class GetUsersAsOrganizationAdminsQuery(Guid id) : IRequest<IEnumerable<BaseUserDto>>
{
	public Guid OrganizationId { get; set; } = id;
}
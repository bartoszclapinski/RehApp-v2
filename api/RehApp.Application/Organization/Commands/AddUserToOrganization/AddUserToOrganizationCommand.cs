using MediatR;
using RehApp.Application.DTOs;
using RehApp.Domain.Entities.Organizations;

namespace RehApp.Application.Organization.Commands.AddUserToOrganization;

public class AddUserToOrganizationCommand() : IRequest<UserOrganizationDto>
{
	public string UserId { get; set; } = default!;
	public Guid OrganizationId { get; set; } = default!;
}
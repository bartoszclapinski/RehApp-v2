using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Commands.UpdateOrganization;

public class UpdateOrganizationCommand : IRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public AddressDto Address { get; set; } = default!;
	public string Phone { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string? AdditionalInfo { get; set; }
}
using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
	public string Id { get; set; } = default!;
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public string PhoneNumber { get; set; } = default!;
	public string Pesel { get; set; } = default!;
	public string Role { get; set; } = default!;
	public string Email { get; set; } = default!;
	public AddressDto Address { get; set; } = default!;
	public string? Specialization { get; set; }
	public string? LicenseNumber { get; set; }
	public string? Department { get; set; }
	public string? AdminLevel { get; set; }
}
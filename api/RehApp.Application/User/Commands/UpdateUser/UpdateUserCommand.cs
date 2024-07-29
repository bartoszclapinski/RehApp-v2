using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
	public string Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public AddressDto Address { get; set; }
	public string? Specialization { get; set; }
	public string? LicenseNumber { get; set; }
	public string? Department { get; set; }
	public string? AdminLevel { get; set; }
}
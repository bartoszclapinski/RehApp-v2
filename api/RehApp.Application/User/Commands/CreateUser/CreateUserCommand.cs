using MediatR;

namespace RehApp.Application.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<string>
{
	public string Email { get; set; } = default!;
	public string Password { get; set; } = default!;
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public string UserRole { get; set; } = default!;
	
	public string? Specialization { get; set; }
	public string? LicenseNumber { get; set; }
	public string? Department { get; set; }
	public string? AdminLevel { get; set; }	
	
	public string Street { get; set; } = default!;
	public string City { get; set; } = default!;
	public string ZipCode { get; set; } = default!;
	public string Country { get; set; } = default!;
	
	public string PhoneNumber { get; set; } = default!;
	public string Pesel { get; set; } = default!;
}
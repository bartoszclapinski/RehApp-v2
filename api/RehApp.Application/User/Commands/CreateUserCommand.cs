using MediatR;

namespace RehApp.Application.User.Commands;

public class CreateUserCommand : IRequest<Guid>
{
	public string Email { get; set; }
	public string Password { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string UserRole { get; set; }
	public string? Specialization { get; set; }
	public string? LicenseNumber { get; set; }
	public string? Department { get; set; }
	public string? AdminLevel { get; set; }	
}
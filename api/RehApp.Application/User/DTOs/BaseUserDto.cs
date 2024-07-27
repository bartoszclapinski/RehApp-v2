using RehApp.Application.DTOs;

namespace RehApp.Application.User.DTOs;

public class BaseUserDto
{
	public string Id { get; set; }
	public string Email { get; set; }
	public string Role { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? LastLoginAt { get; set; }
	public bool IsActive { get; set; }
	public AddressDto Address { get; set; }
	public List<UserOrganizationDto> UserOrganizations { get; set; }
}
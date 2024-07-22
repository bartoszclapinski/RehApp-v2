using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Enums;

namespace RehApp.Domain.Entities.Users;

public class User : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime LastLoginAt { get; set; }
	public bool IsActive { get; set; }
	public UserRole Role { get; set; }
}
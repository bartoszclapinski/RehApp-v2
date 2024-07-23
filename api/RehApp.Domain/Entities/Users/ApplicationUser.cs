using Microsoft.AspNetCore.Identity;

namespace RehApp.Domain.Entities.Users;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? LastLoginAt { get; set; }
	public bool IsActive { get; set; }

	//	Doctor, Physiotherapist
	public string? Specialization { get; set; }
	
	//	Doctor, Physiotherapist, Nurse
	public string? LicenseNumber { get; set; }
	
	//	Nurse
	public string? Department { get; set; }
	
	//	OrganizationAdmin, Admin
	public string? AdminLevel { get; set; }
}
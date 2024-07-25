using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Patients;

namespace RehApp.Domain.Entities.Users;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? LastLoginAt { get; set; }
	public bool IsActive { get; set; }
	public Address Address { get; set; }

	//	Doctor, Physiotherapist
	public string? Specialization { get; set; }
	
	//	Doctor, Physiotherapist, Nurse
	public string? LicenseNumber { get; set; }
	
	//	Nurse
	public string? Department { get; set; }
	
	//	OrganizationAdmin, Admin
	public string? AdminLevel { get; set; }

	//	User - Organization relation
	public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
	
	//	Patient - User relation
	public ICollection<Patient> PatientsAsPhysiotherapist { get; set; }
	public ICollection<Patient> PatientsAsDoctor { get; set; }
	public ICollection<Patient> PatientsAsNurse { get; set; }
}
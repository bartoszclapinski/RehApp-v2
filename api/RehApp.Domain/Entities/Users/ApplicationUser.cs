using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Patients;
using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Entities.Users;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public DateTime CreatedAt { get; set; }
	public DateTime? LastLoginAt { get; set; }
	public bool IsActive { get; set; }
	public Address Address { get; set; } = default!;
	public string Pesel { get; set; } = default!;

	// Doctor, Physiotherapist
	public string? Specialization { get; set; }

	// Doctor, Physiotherapist, Nurse
	public string? LicenseNumber { get; set; }

	// Nurse
	public string? Department { get; set; }

	// OrganizationAdmin, Admin
	public string? AdminLevel { get; set; }

	// User - Organization relation
	public virtual ICollection<UserOrganization>? UserOrganizations { get; set; }

	// Patient - User relation
	public ICollection<Patient>? PatientsAsPhysiotherapist { get; set; }
	public ICollection<Patient>? PatientsAsDoctor { get; set; }
	public ICollection<Patient>? PatientsAsNurse { get; set; }

	// Visit - User relation
	public ICollection<Visit>? CreatedVisits { get; set; }

	
	
}
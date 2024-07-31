using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Entities.Patients;

public class Patient
{
	public Guid Id { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public DateTime DateOfBirth { get; set; }
	public string ConditionDescription { get; set; } = default!;
	public Address Address { get; set; } = default!;
	public string Pesel { get; set; } = default!;
	public string PhoneNumber { get; set; } = default!;

	
	public Guid OrganizationId { get; set; }
	public Organization Organization { get; set; } = default!;

	
	public string? PhysiotherapistId { get; set; }
	public ApplicationUser? Physiotherapist { get; set; }

	public string? DoctorId { get; set; }
	public ApplicationUser? Doctor { get; set; }

	public string? NurseId { get; set; }
	public ApplicationUser? Nurse { get; set; }

	
	public ICollection<Visit> Visits { get; set; }
}
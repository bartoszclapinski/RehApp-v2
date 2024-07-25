using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Entities.Patients;

public class Patient
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string ConditionDescription { get; set; }
	public Address Address { get; set; }

	// Relacje z organizacjami
	public Guid OrganizationId { get; set; }
	public Organization Organization { get; set; }

	//	Relacje z użytkownikami
	public string PhysiotherapistId { get; set; }
	public ApplicationUser Physiotherapist { get; set; }

	public string DoctorId { get; set; }
	public ApplicationUser Doctor { get; set; }

	public string NurseId { get; set; }
	public ApplicationUser Nurse { get; set; }
	
	// Relacje z wizytami
	public ICollection<Visit> Visits { get; set; }
}
namespace RehApp.Application.DTOs;

public class PatientDto
{
	public Guid Id { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public DateTime DateOfBirth { get; set; }
	public string ConditionDescription { get; set; } = default!;
	public AddressDto Address { get; set; } = default!;
	public string Pesel { get; set; } = default!;
	public string PhoneNumber { get; set; } = default!;
	public Guid? OrganizationId { get; set; }
	public string? PhysiotherapistId { get; set; }
	public string? DoctorId { get; set; }
	public string? NurseId { get; set; }
}
namespace RehApp.Application.DTOs;

public class PatientDto
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string ConditionDescription { get; set; }
	public AddressDto Address { get; set; }
	public Guid? OrganizationId { get; set; }
	public string? PhysiotherapistId { get; set; }
	public string? DoctorId { get; set; }
	public string? NurseId { get; set; }
}
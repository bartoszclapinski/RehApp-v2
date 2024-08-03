namespace RehApp.Application.DTOs.VisitDTOs;

public class PatientForVisitListDto
{
	public Guid Id { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public Guid? OrganizationId { get; set; }
}
namespace RehApp.Application.DTOs;

public class VisitDto
{
	public Guid Id { get; set; }
	public DateTime Date { get; set; }
	public string Description { get; set; } = default!;
	public string CreatedByUserId { get; set; } = default!;
	public string PatientName { get; set; } = default!;
	public string OrganizationName { get; set; } = default!;
}
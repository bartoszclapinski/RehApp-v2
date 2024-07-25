namespace RehApp.Application.DTOs;

public class VisitDto
{
	public Guid Id { get; set; }
	public DateTime Date { get; set; }
	public string Description { get; set; }
	public string CreatedByUserId { get; set; }
	public string PatientName { get; set; }
	public string OrganizationName { get; set; }
}
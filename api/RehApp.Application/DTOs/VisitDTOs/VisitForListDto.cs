namespace RehApp.Application.DTOs.VisitDTOs;

public class VisitForListDto
{
	public Guid Id { get; set; }
	public DateTime Date { get; set; }
	public PatientForVisitListDto Patient { get; set; } = default!;
	public BaseUserForVisitListDto User { get; set; } = default!;
}
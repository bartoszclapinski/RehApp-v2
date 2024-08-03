namespace RehApp.Application.DTOs.VisitDTOs
{
	public class VisitDto
	{
		public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; } = default!;
		public PatientDto Patient { get; set; } = default!;
		public BaseUserDto User { get; set; } = default!;
	}
}
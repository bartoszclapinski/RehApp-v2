namespace RehApp.Application.DTOs.VisitDTOs;

public class BaseUserForVisitListDto
{
	public string Id { get; set; }  = default!;
	public string Role { get; set; } = default!;
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
}
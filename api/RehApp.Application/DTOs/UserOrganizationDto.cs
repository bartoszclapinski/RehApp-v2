namespace RehApp.Application.DTOs;

public class UserOrganizationDto
{
	public Guid OrganizationId { get; set; }
	public string OrganizationName { get; set; } = default!;
	public string UserId { get; set; } = default!;
	public string UserName { get; set; } = default!;
}
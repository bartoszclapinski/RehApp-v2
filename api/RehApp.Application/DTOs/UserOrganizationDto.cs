namespace RehApp.Application.DTOs;

public class UserOrganizationDto
{
	public Guid OrganizationId { get; set; }
	public string OrganizationName { get; set; } = default!;
}
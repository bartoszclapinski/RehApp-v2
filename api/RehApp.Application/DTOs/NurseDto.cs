namespace RehApp.Application.DTOs;

public class NurseDto : BaseUserDto
{
	public string Department { get; set; } = default!;
	public string LicenseNumber { get; set; } = default!;
}
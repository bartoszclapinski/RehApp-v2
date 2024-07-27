namespace RehApp.Application.User.DTOs;

public class NurseDto : BaseUserDto
{
	public string Department { get; set; }
	public string LicenseNumber { get; set; }
}
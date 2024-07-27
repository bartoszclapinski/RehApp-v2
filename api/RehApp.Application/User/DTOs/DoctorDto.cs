namespace RehApp.Application.User.DTOs;

public class DoctorDto : BaseUserDto
{
	public string Specialization { get; set; }
	public string LicenseNumber { get; set; }
}
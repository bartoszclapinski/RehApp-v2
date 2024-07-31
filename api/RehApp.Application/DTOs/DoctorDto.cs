namespace RehApp.Application.DTOs;

public class DoctorDto : BaseUserDto
{
	public string Specialization { get; set; } = default!;
	public string LicenseNumber { get; set; } = default!;
}
namespace RehApp.Domain.Entities.Users;

public class MedicalProfessional : User
{
	public string Specialization { get; set; }
	public string LicenseNumber { get; set; }
}
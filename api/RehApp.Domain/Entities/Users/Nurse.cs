namespace RehApp.Domain.Entities.Users;

public class Nurse : User
{
	public string Department { get; set; }
	public string NursingLicenseNumber { get; set; }
}
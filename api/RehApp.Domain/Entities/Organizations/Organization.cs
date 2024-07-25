using System.Net.Sockets;
using RehApp.Domain.Entities.Patients;
using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Entities.Organizations;

public class Organization
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public Address Address { get; set; }
	public DateTime CreatedAt { get; set; }

	//	Organization - User relation
	public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
	
	//	Organization - Patient relation
	public ICollection<Patient> Patients { get; set; }
	
	//	Organization - Visit relation
	public ICollection<Visit> Visits { get; set; }
}
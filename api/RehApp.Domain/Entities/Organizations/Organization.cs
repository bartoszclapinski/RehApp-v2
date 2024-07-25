using System.Net.Sockets;
using RehApp.Domain.Entities.Patients;

namespace RehApp.Domain.Entities.Organizations;

public class Organization
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public Address Address { get; set; }
	public DateTime CreatedAt { get; set; }

	public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
	public ICollection<Patient> Patients { get; set; }
}
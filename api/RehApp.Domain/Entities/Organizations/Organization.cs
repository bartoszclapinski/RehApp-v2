using System.Net.Sockets;

namespace RehApp.Domain.Entities.Organizations;

public class Organization
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public Address Address { get; set; }
	public DateTime CreatedAt { get; set; }

	public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
}
using RehApp.Domain.Entities.Users;

namespace RehApp.Domain.Entities.Organizations;

public class UserOrganization
{
	public string UserId { get; set; }
	public ApplicationUser User { get; set; }

	public Guid OrganizationId { get; set; }
	public Organization Organization { get; set; }

	public DateTime JoinedAt { get; set; }
}
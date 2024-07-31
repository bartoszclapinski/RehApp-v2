using RehApp.Domain.Entities.Users;

namespace RehApp.Domain.Entities.Organizations;

public class UserOrganization
{
	public string UserId { get; set; } = default!;
	public ApplicationUser User { get; set; } = default!;

	public Guid OrganizationId { get; set; }
	public Organization Organization { get; set; }= default!;

	public DateTime JoinedAt { get; set; }
}
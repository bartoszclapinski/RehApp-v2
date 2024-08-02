using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;

namespace RehApp.Domain.Interfaces
{
	public interface IOrganizationRepository
	{
		Task<Organization> AddAsync(Organization organization);
		Task<Organization?> GetByIdAsync(Guid id);
		Task<Organization?> GetByIdWithUsersAsync(Guid id);
		Task<IEnumerable<Organization>> GetAllAsync();
		Task<IEnumerable<Organization>> GetByUserIdAsync(string userId);
		Task<IEnumerable<ApplicationUser>> GetUsersByOrganizationId(Guid organizationId);
		Task SaveChangesAsync();
	}
}
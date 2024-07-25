using RehApp.Domain.Entities.Organizations;

namespace RehApp.Domain.Interfaces
{
	public interface IOrganizationRepository
	{
		Task<Organization> AddAsync(Organization organization);
		Task<Organization?> GetByIdAsync(Guid id);
	}
}
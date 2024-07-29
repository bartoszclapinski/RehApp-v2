using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Interfaces;
using RehApp.Infrastructure.Data;

namespace RehApp.Infrastructure.Repositories
{
	public class OrganizationRepository(ApplicationDbContext context) : IOrganizationRepository
	{
		public async Task<Organization> AddAsync(Organization organization)
		{
			await context.Organizations.AddAsync(organization);
			await context.SaveChangesAsync();
			
			return organization;
		}

		public async Task<Organization?> GetByIdAsync(Guid id)
		{
			Organization? organization = await context.Organizations
				.Include(o => o.Address) 
				.FirstOrDefaultAsync(o => o.Id == id);
			
			return organization;
		}

		public async Task<IEnumerable<Organization>> GetAllAsync()
		{
			var organizations = await context.Organizations.ToListAsync();
			return organizations;
		}


	}
}
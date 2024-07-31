using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;
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
			var organizations = await context.Organizations
				.Include(o => o.UserOrganizations)
				.OrderByDescending(o => o.CreatedAt)
				.ToListAsync();
			
			return organizations;
		}

		public async Task<IEnumerable<Organization>> GetByUserIdAsync(string userId)
		{
			var result = await context.Organizations
				.Include(o => o.UserOrganizations)
				.Where(o => o.UserOrganizations.Any(ur => ur.UserId == userId))
				.ToListAsync();

			return result;
		}

		public async Task<IEnumerable<ApplicationUser>> GetUsersByOrganizationId(Guid organizationId)
		{
			var users = await context.UserOrganizations
				.Where(uo => uo.OrganizationId == organizationId)
				.Select(uo => uo.User)
				.ToListAsync();

			return users;
		}

		public async Task SaveChangesAsync() => await context.SaveChangesAsync();
		


	}
}
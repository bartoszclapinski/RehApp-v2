using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Constants;
using RehApp.Infrastructure.Data;

namespace RehApp.Infrastructure.Seeders;

public class DataSeed(ApplicationDbContext context) : IDataSeed
{
	public async Task Seed()
	{
		if (await context.Database.CanConnectAsync())
		{
			if (!context.Roles.Any())
			{
				var roles = GetRoles();
				context.Roles.AddRange(roles);
				await context.SaveChangesAsync();
			}
		}
	}

	private IEnumerable<IdentityRole> GetRoles()
	{
		List<IdentityRole> roles =
		[
			new IdentityRole(UserRoles.Admin),
			new IdentityRole(UserRoles.OrganizationAdmin),
			new IdentityRole(UserRoles.Doctor),
			new IdentityRole(UserRoles.Physiotherapist),
			new IdentityRole(UserRoles.Nurse)
		];

		return roles;
	}
}
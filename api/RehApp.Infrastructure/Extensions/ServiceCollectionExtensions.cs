using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RehApp.Domain.Entities.Users;
using RehApp.Infrastructure.Data;
using RehApp.Infrastructure.Seeders;

namespace RehApp.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(
			o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		services.AddIdentityCore<ApplicationUser>(options =>
			{
				// Password settings
			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>();

		services.AddScoped<IDataSeed, DataSeed>();

	}
}
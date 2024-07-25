using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;
using RehApp.Infrastructure.Data;
using RehApp.Infrastructure.Repositories;
using RehApp.Infrastructure.Seeders;

namespace RehApp.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(
			o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		services.AddIdentityApiEndpoints<ApplicationUser>()
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>();

		services.AddScoped<IDataSeed, DataSeed>();
		services.AddScoped<IOrganizationRepository, OrganizationRepository>();
		services.AddScoped<IPatientRepository, PatientRepository>();
		services.AddScoped<IVisitRepository, VisitRepository>();
	}
}
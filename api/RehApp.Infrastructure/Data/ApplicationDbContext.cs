using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;


namespace RehApp.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
	: IdentityDbContext<ApplicationUser>(options)
{
	
	public DbSet<Organization> Organizations { get; set; }
	public DbSet<UserOrganization> UserOrganizations { get; set; }
	
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
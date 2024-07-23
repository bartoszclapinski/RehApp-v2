using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Users;


namespace RehApp.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
	: IdentityDbContext<ApplicationUser>(options)
{
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		
		
	}
}
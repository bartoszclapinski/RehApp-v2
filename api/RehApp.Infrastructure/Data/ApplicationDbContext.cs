using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Enums;

namespace RehApp.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
	public DbSet<Doctor> Doctors { get; set; }
	public DbSet<Physiotherapist> Physiotherapists { get; set; }
	public DbSet<OrganizationAdmin> OrganizationAdmins { get; set; }
	public DbSet<Nurse> Nurses { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		
		builder.Entity<User>()
			.HasDiscriminator(u => u.Role)
			.HasValue<User>(UserRole.SystemAdmin)
			.HasValue<Doctor>(UserRole.Doctor)
			.HasValue<Physiotherapist>(UserRole.Physiotherapist)
			.HasValue<OrganizationAdmin>(UserRole.OrganizationAdmin)
			.HasValue<Nurse>(UserRole.Nurse);
	}
}
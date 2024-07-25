using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RehApp.Domain.Entities.Users;

namespace RehApp.Infrastructure.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{

	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.OwnsOne(u => u.Address,
			addressBuilder =>
			{
				addressBuilder.WithOwner();
				addressBuilder.Property(a => a.Street).IsRequired();
				addressBuilder.Property(a => a.City).IsRequired();
				addressBuilder.Property(a => a.ZipCode).IsRequired();
				addressBuilder.Property(a => a.Country).IsRequired();
			});
		
		builder.HasMany(u => u.PatientsAsPhysiotherapist)
			.WithOne(p => p.Physiotherapist)
			.HasForeignKey(p => p.PhysiotherapistId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(u => u.PatientsAsDoctor)
			.WithOne(p => p.Doctor)
			.HasForeignKey(p => p.DoctorId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(u => u.PatientsAsNurse)
			.WithOne(p => p.Nurse)
			.HasForeignKey(p => p.NurseId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
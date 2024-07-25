using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RehApp.Domain.Entities.Organizations;

namespace RehApp.Infrastructure.Data.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{

	public void Configure(EntityTypeBuilder<Organization> builder)
	{
		builder.OwnsOne(o => o.Address,
			addressBuilder =>
			{
				addressBuilder.WithOwner();
				addressBuilder.Property(a => a.Street).IsRequired();
				addressBuilder.Property(a => a.City).IsRequired();
				addressBuilder.Property(a => a.ZipCode).IsRequired();
				addressBuilder.Property(a => a.Country).IsRequired();
			});
		
		builder.HasMany(o => o.Patients)
			.WithOne(p => p.Organization)
			.HasForeignKey(p => p.OrganizationId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
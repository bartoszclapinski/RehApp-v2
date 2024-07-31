using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RehApp.Domain.Entities.Organizations;

namespace RehApp.Infrastructure.Data.Configurations
{
	public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
	{
		public void Configure(EntityTypeBuilder<Organization> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
			builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
			builder.Property(e => e.Phone).IsRequired().HasMaxLength(15);
			builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
			builder.Property(e => e.TaxNumber).IsRequired().HasMaxLength(20); // New field
			builder.Property(e => e.CreatedAt).IsRequired();
			builder.Property(e => e.AdditionalInfo).HasMaxLength(1000);

			builder.OwnsOne(e => e.Address, addressBuilder =>
			{
				addressBuilder.WithOwner();
				addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100);
				addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(50);
				addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10);
				addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(50);
			});
		}
	}
}
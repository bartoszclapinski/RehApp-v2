using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RehApp.Domain.Entities.Organizations;

namespace RehApp.Infrastructure.Data.Configurations;

public class UserOrganizationConfiguration : IEntityTypeConfiguration<UserOrganization>
{

	public void Configure(EntityTypeBuilder<UserOrganization> builder)
	{
		builder.HasKey(uo => new { uo.UserId, uo.OrganizationId });

		builder.HasOne(uo => uo.User)
			.WithMany(u => u.UserOrganizations)
			.HasForeignKey(uo => uo.UserId)
			.OnDelete(DeleteBehavior.Restrict);
		
		builder.HasOne(uo => uo.Organization)
			.WithMany(o => o.UserOrganizations)
			.HasForeignKey(uo => uo.OrganizationId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(uo => uo.UserId).HasMaxLength(450);
	}
}
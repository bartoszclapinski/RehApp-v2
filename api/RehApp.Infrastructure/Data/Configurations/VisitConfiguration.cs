using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RehApp.Domain.Entities.Visits;

namespace RehApp.Infrastructure.Data.Configurations
{
	public class VisitConfiguration : IEntityTypeConfiguration<Visit>
	{
		public void Configure(EntityTypeBuilder<Visit> builder)
		{
			builder.HasKey(v => v.Id);

			builder.Property(v => v.Date).IsRequired();
			builder.Property(v => v.Description).IsRequired();

			builder.HasOne(v => v.CreatedByUser)
				.WithMany(u => u.CreatedVisits)
				.HasForeignKey(v => v.CreatedByUserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(v => v.Patient)
				.WithMany(p => p.Visits)
				.HasForeignKey(v => v.PatientId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(v => v.Organization)
				.WithMany(o => o.Visits)
				.HasForeignKey(v => v.OrganizationId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
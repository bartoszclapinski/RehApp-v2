using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RehApp.Domain.Entities.Patients;

namespace RehApp.Infrastructure.Data.Configurations
{
	public class PatientConfiguration : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.FirstName).IsRequired();
			builder.Property(e => e.LastName).IsRequired();
			builder.Property(e => e.DateOfBirth).IsRequired();
			builder.Property(e => e.ConditionDescription).IsRequired();

			builder.HasOne(e => e.Organization)
				.WithMany(o => o.Patients)
				.HasForeignKey(e => e.OrganizationId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Physiotherapist)
				.WithMany(u => u.PatientsAsPhysiotherapist)
				.HasForeignKey(e => e.PhysiotherapistId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Doctor)
				.WithMany(u => u.PatientsAsDoctor)
				.HasForeignKey(e => e.DoctorId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Nurse)
				.WithMany(u => u.PatientsAsNurse)
				.HasForeignKey(e => e.NurseId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.OwnsOne(e => e.Address, addressBuilder =>
			{
				addressBuilder.WithOwner();
				addressBuilder.Property(a => a.Street).IsRequired();
				addressBuilder.Property(a => a.City).IsRequired();
				addressBuilder.Property(a => a.ZipCode).IsRequired();
				addressBuilder.Property(a => a.Country).IsRequired();
			});
		}
	}
}
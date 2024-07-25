using System;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Entities.Patients;
using RehApp.Domain.Entities.Organizations;

namespace RehApp.Domain.Entities.Visits
{
	public class Visit
	{
		public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }

		public string CreatedByUserId { get; set; }
		public ApplicationUser CreatedByUser { get; set; }

		public Guid PatientId { get; set; }
		public Patient Patient { get; set; }

		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }
	}
}
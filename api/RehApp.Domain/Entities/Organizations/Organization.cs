using RehApp.Domain.Entities.Patients;
using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Entities.Organizations;

public class Organization
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public Address Address { get; set; } = default!;
	public DateTime CreatedAt { get; set; }
	public string Phone { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string? AdditionalInfo { get; set; }
	public string TaxNumber { get; set; } = default!;

	public virtual ICollection<UserOrganization>? UserOrganizations { get; set; }
	public ICollection<Patient>? Patients { get; set; }
	public ICollection<Visit>? Visits { get; set; }
}
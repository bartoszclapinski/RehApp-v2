using MediatR;

namespace RehApp.Application.Patient.Commands.CreatePatient;

public record CreatePatientCommand : IRequest<Guid>
{
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public DateTime DateOfBirth { get; set; } = default!;
	public string ConditionDescription { get; set; } = default!;
	public string Street { get; set; } = default!;
	public string City { get; set; } = default!;
	public string ZipCode { get; set; } = default!;
	public string Country { get; set; } = default!;
	public string Pesel { get; set; } = default!;
	public string PhoneNumber { get; set; } = default!;
	public Guid OrganizationId { get; set; }
	public string? PhysiotherapistId { get; set; }
	public string? DoctorId { get; set; }
	public string? NurseId { get; set; }
}
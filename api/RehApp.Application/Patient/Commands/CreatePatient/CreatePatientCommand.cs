using MediatR;

namespace RehApp.Application.Patient.Commands.CreatePatient;

public record CreatePatientCommand : IRequest<Guid>
{
	public string FirstName { get; init; }
	public string LastName { get; init; }
	public DateTime DateOfBirth { get; init; }
	public string ConditionDescription { get; init; }
	public string Street { get; init; }
	public string City { get; init; }
	public string ZipCode { get; init; }
	public string Country { get; init; }
	public Guid? OrganizationId { get; init; }
	public string? PhysiotherapistId { get; init; }
	public string? DoctorId { get; init; }
	public string? NurseId { get; init; }
}
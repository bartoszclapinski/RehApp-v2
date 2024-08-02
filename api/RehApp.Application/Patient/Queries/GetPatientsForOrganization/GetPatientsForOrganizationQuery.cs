using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Patient.Queries.GetPatientsForOrganization;

public class GetPatientsForOrganizationQuery : IRequest<List<PatientDto>>
{
	public Guid OrganizationId { get; set; }
}
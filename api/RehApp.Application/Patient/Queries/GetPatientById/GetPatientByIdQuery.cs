using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Patient.Queries.GetPatientById;

public record GetPatientByIdQuery(Guid Id) : IRequest<PatientDto>;
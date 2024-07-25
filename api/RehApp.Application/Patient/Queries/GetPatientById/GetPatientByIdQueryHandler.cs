using AutoMapper;
using MediatR;
using RehApp.Application.DTOs;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Patient.Queries.GetPatientById;

public class GetPatientByIdQueryHandler(IPatientRepository patientRepository, IMapper mapper)
	: IRequestHandler<GetPatientByIdQuery, PatientDto>
{
	public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
	{
		Domain.Entities.Patients.Patient? patient = await patientRepository.GetByIdAsync(request.Id);
		if (patient is null) throw new Exception($"Patient with ID {request.Id} not found.");
		
		return mapper.Map<PatientDto>(patient);
	}
}
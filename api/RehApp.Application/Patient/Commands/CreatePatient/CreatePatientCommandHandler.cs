using AutoMapper;
using MediatR;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Patient.Commands.CreatePatient;

public class CreatePatientCommandHandler(
	IPatientRepository patientRepository, 
	IMapper mapper) : IRequestHandler<CreatePatientCommand, Guid>
{
	public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
	{
		var patient = mapper.Map<Domain.Entities.Patients.Patient>(request);
		await patientRepository.AddAsync(patient);
		return patient.Id;
	}
}
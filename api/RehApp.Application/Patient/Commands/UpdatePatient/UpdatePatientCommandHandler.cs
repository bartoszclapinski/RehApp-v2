using AutoMapper;
using MediatR;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Patient.Commands.UpdatePatient;

public class UpdatePatientCommandHandler(
	IPatientRepository patientRepository,
	IMapper mapper) : IRequestHandler<UpdatePatientCommand>
{
	public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
	{
		var patient = await patientRepository.GetByIdAsync(request.Id);
		if (patient == null) throw new Exception("Patient not found");

		mapper.Map(request, patient);
		await patientRepository.UpdateAsync(patient);
	}
}
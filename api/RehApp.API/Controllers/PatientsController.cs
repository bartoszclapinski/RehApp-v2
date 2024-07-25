using MediatR;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.Patient.Commands.CreatePatient;
using RehApp.Application.Patient.Queries.GetPatientById;

namespace RehApp.API.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController(IMediator mediator) : ControllerBase
{
	[HttpGet("{id}")]
	public async Task<IActionResult> GetPatientById(Guid id)
	{
		PatientDto patient = await mediator.Send(new GetPatientByIdQuery(id));
		return Ok(patient);	
	}
	
	[HttpPost]
	public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
	{
		Guid patientId = await mediator.Send(command);
		return CreatedAtAction(nameof(GetPatientById), new { id = patientId }, command);
	}
	
}
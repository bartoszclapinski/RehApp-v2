using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.Patient.Commands.CreatePatient;
using RehApp.Application.Patient.Commands.UpdatePatient;
using RehApp.Application.Patient.Queries.GetPatientById;
using RehApp.Application.Patient.Queries.GetPatientsForOrganization;

namespace RehApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/patients")]
public class PatientsController(IMediator mediator) : ControllerBase
{
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetPatientById(Guid id)
	{
		PatientDto patient = await mediator.Send(new GetPatientByIdQuery(id));
		return Ok(patient);	
	}
	
	[HttpPost("create")]
	public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
	{
		Guid patientId = await mediator.Send(command);
		return CreatedAtAction(nameof(GetPatientById), new { id = patientId }, command);
	}
	
	[HttpGet("organization/{organizationId}")]
	public async Task<IActionResult> GetPatientsForOrganization(Guid organizationId)
	{
		var query = new GetPatientsForOrganizationQuery { OrganizationId = organizationId };
		var patients = await mediator.Send(query);
		return Ok(patients);
	}
	
	[HttpPut("update")]
	public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
	{
		await mediator.Send(command);
		return NoContent();
	}
	
}
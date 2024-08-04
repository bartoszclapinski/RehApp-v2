using MediatR;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.DTOs.VisitDTOs;
using RehApp.Application.Visit.Commands.CreateVisit;
using RehApp.Application.Visit.Commands.DeleteVisit;
using RehApp.Application.Visit.Commands.UpdateVisit;
using RehApp.Application.Visit.Queries.GetAllVisitsForOrganization;
using RehApp.Application.Visit.Queries.GetVisitById;
using RehApp.Application.Visit.Queries.GetVisitsByPatientIdForUser;
using RehApp.Application.Visit.Queries.GetVisitsByUserForOrganization;

namespace RehApp.API.Controllers;

[ApiController]
[Route("api/visits")]
public class VisitsController(IMediator mediator) : ControllerBase
{
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		VisitDto visit = await mediator.Send(new GetVisitByIdQuery(id));
		return Ok(visit);
	}

	[HttpPost("add-visit")]
	public async Task<IActionResult> AddVisit(CreateVisitCommand command)
	{
		Guid visitId = await mediator.Send(command);
		return Ok();
	}
	
	[HttpGet("user/{userId}/organization/{organizationId}")]
	public async Task<IActionResult> GetVisitsByUserForOrganization(string userId, Guid organizationId)
	{
		var query = new GetVisitsByUserForOrganizationQuery { UserId = userId, OrganizationId = organizationId };
		var visits = await mediator.Send(query);
		
		return Ok(visits);
	}
	
	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateVisit(Guid id, [FromBody] UpdateVisitCommand command)
	{
		if (id != command.Id) return BadRequest("Visit ID mismatch");

		await mediator.Send(command);
		return NoContent();
	}
	
	[HttpGet("patient/{patientId:guid}/user/{userId}")]
	public async Task<IActionResult> GetVisitsByPatientIdForUser(Guid patientId, string userId)
	{
		var query = new GetVisitsByPatientIdForUserQuery { PatientId = patientId, UserId = userId };
		var visits = await mediator.Send(query);
		return Ok(visits);
	}

	[HttpGet("organization/{organizationId:guid}")]
	public async Task<IActionResult> GetAllVisitsForOrganization(Guid organizationId)
	{
		var query = new GetAllVisitsForOrganizationQuery { OrganizationId = organizationId };
		var visits = await mediator.Send(query);
		return Ok(visits);
	}
	
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteVisit(Guid id)
	{
		var command = new DeleteVisitCommand { Id = id };
		await mediator.Send(command);
		return NoContent();
	}
	
	
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.Visit.Commands.CreateVisit;
using RehApp.Application.Visit.Queries.GetVisitById;

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

	[HttpPost]
	public async Task<IActionResult> AddVisit(CreateVisitCommand command)
	{
		Guid visitId = await mediator.Send(command);
		return CreatedAtAction(nameof(GetById), new { id = visitId }, command);
	}
}
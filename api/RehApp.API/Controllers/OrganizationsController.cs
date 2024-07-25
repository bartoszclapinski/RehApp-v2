using MediatR;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.Organization.Commands.CreateOrganization;
using RehApp.Application.Organization.Queries.GetOrganizationById;

namespace RehApp.API.Controllers;

[ApiController]
[Route("api/organizations")]
public class OrganizationsController(IMediator mediator) : ControllerBase
{
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		OrganizationDto organization = await mediator.Send(new GetOrganizationByIdQuery(id));
		return Ok(organization);
	}
	
	[HttpPost]
	public async Task<IActionResult> CreateOrganization(CreateOrganizationCommand command)
	{
		Guid organizationId = await mediator.Send(command);
		return CreatedAtAction(nameof(GetById), new { id = organizationId }, command);
	}
}
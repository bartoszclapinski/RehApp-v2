using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.Organization.Commands.AddUserToOrganization;
using RehApp.Application.Organization.Commands.CreateOrganization;
using RehApp.Application.Organization.Commands.UpdateOrganization;
using RehApp.Application.Organization.Queries.GetAllOrganizations;
using RehApp.Application.Organization.Queries.GetAllOrganizationsForUserId;
using RehApp.Application.Organization.Queries.GetOrganizationById;
using RehApp.Application.Organization.Queries.GetUsersNotInOrganization;
using RehApp.Domain.Constants;

namespace RehApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/organizations")]
public class OrganizationsController(IMediator mediator) : ControllerBase
{
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		OrganizationDto organization = await mediator.Send(new GetOrganizationByIdQuery(id));
		return Ok(organization);
	}
	
	[Authorize(Roles = UserRoles.Admin)]
	[HttpPost("create")]
	public async Task<IActionResult> CreateOrganization(CreateOrganizationCommand command)
	{
		Guid organizationId = await mediator.Send(command);
		return CreatedAtAction(nameof(GetById), new { id = organizationId }, command);
	}
	
	[Authorize(Roles = UserRoles.Admin)]
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var organizations = await mediator.Send(new GetAllOrganizationsQuery());
		return Ok(organizations);
	}
	
	[Authorize]
	[HttpGet("user/{userId}")]
	public async Task<IActionResult> GetByUserId(string userId)
	{
		var organizations = await mediator.Send(new GetAllOrganizationsForUserIdQuery(userId));
		return Ok(organizations);
	}
	
	[Authorize(Roles = UserRoles.Admin + "," + UserRoles.OrganizationAdmin)]
	[HttpPatch("update")]
	public async Task<IActionResult> UpdateOrganization(UpdateOrganizationCommand command)
	{
		await mediator.Send(command);
		return NoContent();
	}
	
	//[Authorize(Roles = UserRoles.Admin)]
	[AllowAnonymous]
	[HttpPost("add-user")]
	public async Task<IActionResult> AddUserToOrganization(AddUserToOrganizationCommand command)
	{
		var userOrganization = await mediator.Send(command);
		return Ok(userOrganization);
	}
	
	//[Authorize(Roles = UserRoles.Admin + "," + UserRoles.OrganizationAdmin)]
	[AllowAnonymous]
	[HttpGet("users-not-in-organization/{organizationId:guid}")]
	public async Task<IActionResult> GetUsersNotInOrganization(Guid organizationId)
	{
		var query = new GetUsersNotInOrganizationQuery { OrganizationId = organizationId };
		var users = await mediator.Send(query);
		return Ok(users);
	}
	
}
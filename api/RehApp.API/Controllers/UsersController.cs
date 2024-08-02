using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.DTOs;
using RehApp.Application.Organization.Queries.GetUsersAsOrganizationAdmins;
using RehApp.Application.User.Commands.CreateUser;
using RehApp.Application.User.Commands.UpdateUser;
using RehApp.Application.User.Queries.GetAllUsers;
using RehApp.Application.User.Queries.GetCurrentUser;
using RehApp.Application.User.Queries.GetUserById;
using RehApp.Application.User.Queries.GetUsersForOrganization;

namespace RehApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/identity")]
public class UsersController(IMediator mediator) : ControllerBase
{
	[AllowAnonymous]
	[HttpPost]
	[Route("create")]
	public async Task<IActionResult> CreateUser(CreateUserCommand command)
	{
		var userId = await mediator.Send(command);
		return Ok();
	}
	
	[HttpGet("current")]
	public async Task<IActionResult> GetCurrentUser()
	{
		BaseUserDto? user = await mediator.Send(new GetCurrentUserQuery());
		if (user is null) return NotFound();
		return Ok(user);
	}

	//	Update User
	[Authorize]
	[HttpPatch("update")]
	public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
	{
		await mediator.Send(command);
		return NoContent();
	}
	
	//	Get users with role "OrganizationAdmin" by organizationId
	[HttpGet("for-admins/{organizationId:guid}")]
	public async Task<IActionResult> GetUsersAsOrganizationAdmins(Guid organizationId)
	{
		var users = await mediator.Send(new GetUsersAsOrganizationAdminsQuery(organizationId));
		return Ok(users);
	}
	
	//	Get all users with roles for admins
	[Authorize(Roles = "Admin")]
	[HttpGet("all-users")]
	public async Task<IActionResult> GetAllUsers()
	{
		var users = await mediator.Send(new GetAllUsersQuery());
		return Ok(users);
	}
	
	[AllowAnonymous]
	[HttpGet("{userId}")]
	public async Task<IActionResult> GetUserById(string userId)
	{
		var query = new GetUserByIdQuery { UserId = userId };
		var user = await mediator.Send(query);
		return Ok(user);
	}
	
	[AllowAnonymous]
	[HttpGet("users-in-organization/{organizationId}")]
	public async Task<IActionResult> GetUsersForOrganization(Guid organizationId)
	{
		var query = new GetUsersForOrganizationQuery { OrganizationId = organizationId };
		var users = await mediator.Send(query);
		return Ok(users);
	}
	
}
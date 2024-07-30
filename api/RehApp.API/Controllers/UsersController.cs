using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.Organization.Queries.GetUsersAsOrganizationAdmins;
using RehApp.Application.User.Commands.CreateUser;
using RehApp.Application.User.Commands.UpdateUser;
using RehApp.Application.User.DTOs;
using RehApp.Application.User.Queries.GetAllUsers;
using RehApp.Application.User.Queries.GetCurrentUser;

namespace RehApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/identity")]
public class UsersController(IMediator mediator) : ControllerBase
{
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
	[HttpGet("all-users")]
	public async Task<IActionResult> GetAllUsers()
	{
		var users = await mediator.Send(new GetAllUsersQuery());
		return Ok(users);
	}
	
}
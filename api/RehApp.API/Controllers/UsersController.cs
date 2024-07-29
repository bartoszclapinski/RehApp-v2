using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.User.Commands.CreateUser;
using RehApp.Application.User.Commands.UpdateUser;
using RehApp.Application.User.DTOs;
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
		return Ok(userId);
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
	
}
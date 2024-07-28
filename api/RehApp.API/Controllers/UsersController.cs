using MediatR;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.User.Commands;
using RehApp.Application.User.DTOs;
using RehApp.Application.User.Queries.GetCurrentUser;

namespace RehApp.API.Controllers;

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
}
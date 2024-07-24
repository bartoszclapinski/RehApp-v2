using MediatR;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.User.Commands;

namespace RehApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> CreateUser(CreateUserCommand command)
	{
		Guid userId = await mediator.Send(command);
		return Ok(userId);
	}
	
}
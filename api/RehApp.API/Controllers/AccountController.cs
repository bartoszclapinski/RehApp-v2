using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehApp.Application.Account.Commands.ChangePassword;
using Microsoft.AspNetCore.Identity;

namespace RehApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/account")]
public class AccountController(IMediator mediator) : ControllerBase
{
	[HttpPost("change-password")]
	public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
	{
		IdentityResult result = await mediator.Send(command);
		if (result.Succeeded) return NoContent();
		
		var errors = result.Errors.Select(x => x.Description);
		return BadRequest("Password change failed: " + string.Join(", ", errors));
	}
}
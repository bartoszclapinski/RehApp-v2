using MediatR;
using Microsoft.AspNetCore.Identity;

namespace RehApp.Application.Account.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<IdentityResult>
{
	public string Id { get; set; } = default!;
	public string CurrentPassword { get; set; } = default!;
	public string NewPassword { get; set; } = default!;
}
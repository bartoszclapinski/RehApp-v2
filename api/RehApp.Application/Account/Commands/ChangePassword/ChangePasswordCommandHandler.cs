using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.Account.Commands.ChangePassword;

public class ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager) 
	: IRequestHandler<ChangePasswordCommand, IdentityResult>
{
	public async Task<IdentityResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
	{
		ApplicationUser? user = await userManager.FindByIdAsync(request.Id);
		if (user is null) throw new Exception($"User with id: {request.Id} not found");
		
		IdentityResult result = await userManager
			.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

		return result;
	}
}
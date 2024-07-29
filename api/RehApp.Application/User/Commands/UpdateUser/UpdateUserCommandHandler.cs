using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<UpdateUserCommand>
{

	public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		ApplicationUser? user = await userManager.FindByIdAsync(request.Id);
		if (user is null) throw new Exception("User not found");

		mapper.Map(request, user);
		IdentityResult result = await userManager.UpdateAsync(user);
		if (!result.Succeeded) throw new Exception("User update failed");
	}
}
using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(
	UserManager<ApplicationUser> userManager,
	IMapper mapper, IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateUserCommand>
{

	public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		var currentUser = httpContextAccessor.HttpContext?.User 
		                  ?? throw new InvalidOperationException("User context is not available");
		var currentUserId = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
		var isAdmin = currentUser.IsInRole("Admin");

		if (!isAdmin && currentUserId != request.Id)
		{
			throw new UnauthorizedAccessException("You are not authorized to update this user.");
		}
		
		ApplicationUser? user = await userManager.FindByIdAsync(request.Id);
		if (user is null) throw new Exception("User not found");

		mapper.Map(request, user);
		user.PhoneNumber = request.PhoneNumber;
		IdentityResult result = await userManager.UpdateAsync(user);
		if (!result.Succeeded) throw new Exception("User update failed");
	}
}
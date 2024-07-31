using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Commands.CreateUser;

public class CreateUserCommandHandle(
	UserManager<ApplicationUser> userManager,
	RoleManager<IdentityRole> roleManager,
	IMapper mapper) : IRequestHandler<CreateUserCommand, string>
{

	public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		ApplicationUser? userExists = await userManager.FindByEmailAsync(request.Email);
		if (userExists != null) throw new Exception("User already exists");
		
		IdentityRole? role = await roleManager.FindByNameAsync(request.UserRole);
		if (role is null) throw new Exception($"Role '{request.UserRole}' does not exist.");
		
		var user = mapper.Map<ApplicationUser>(request);
		user.PhoneNumber = request.PhoneNumber;
		
		IdentityResult result = await userManager.CreateAsync(user, request.Password);
		if (!result.Succeeded) throw new Exception("User creation failed");
		
		await userManager.AddToRoleAsync(user, role.Name!);
		return user.Id;
	}
}
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.DTOs;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler(
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetUserByIdQuery, BaseUserDto>
{
	public async Task<BaseUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(request.UserId);
		if (user == null) throw new Exception("User not found");

		var userDto = mapper.Map<BaseUserDto>(user);
		var roles = await userManager.GetRolesAsync(user);
		userDto.Role = roles.FirstOrDefault()!;

		return userDto;
	}
}
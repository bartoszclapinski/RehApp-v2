using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehApp.Application.DTOs;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetAllUsersQuery, IEnumerable<BaseUserDto>>
{
	public async Task<IEnumerable<BaseUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
	{
		var users = await userManager.Users.ToListAsync(cancellationToken);

		var usersWithRoles = new List<BaseUserDto>();
		foreach (ApplicationUser user in users)
		{
			var userDto = mapper.Map<BaseUserDto>(user);
			var roles = await userManager.GetRolesAsync(user);
			userDto.Role = roles.FirstOrDefault()!;
			usersWithRoles.Add(userDto);
		}

		return usersWithRoles;
	}
}
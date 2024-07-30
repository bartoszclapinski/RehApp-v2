using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehApp.Application.Organization.Queries.GetAllOrganizations;
using RehApp.Application.User.DTOs;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllApplicationUserDto>> 
{
	public async Task<IEnumerable<GetAllApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
	{
		var users = await userManager.Users.ToListAsync(cancellationToken);
		
		var usersWithRoles = new List<GetAllApplicationUserDto>();
		foreach (ApplicationUser user in users)
		{
			var userDto = mapper.Map<GetAllApplicationUserDto>(user);
			var roles = await userManager.GetRolesAsync(user);
			userDto.Role = roles.FirstOrDefault()!;
			usersWithRoles.Add(userDto);
		}

		return usersWithRoles;

	}
}
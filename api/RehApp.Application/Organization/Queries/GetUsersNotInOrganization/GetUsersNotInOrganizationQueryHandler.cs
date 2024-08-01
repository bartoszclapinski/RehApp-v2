using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehApp.Application.DTOs;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Organization.Queries.GetUsersNotInOrganization;

public class GetUsersNotInOrganizationQueryHandler(
	UserManager<ApplicationUser> userManager,
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<GetUsersNotInOrganizationQuery, IEnumerable<BaseUserDto>>
{
	public async Task<IEnumerable<BaseUserDto>> Handle(GetUsersNotInOrganizationQuery request, CancellationToken cancellationToken)
	{
		var organization = await organizationRepository.GetByIdAsync(request.OrganizationId);
		if (organization is null) throw new Exception("Organization not found");
		
		var allUsers = await userManager.Users.ToListAsync(cancellationToken: cancellationToken);
		
		organization.UserOrganizations ??= new List<UserOrganization>();
		var usersInOrganization = organization.UserOrganizations.Select(uo => uo.UserId).ToList(); 

		var usersNotInOrganization = allUsers
			.Where(user => !usersInOrganization.Contains(user.Id))
			.Select(user => 
			{
				var userDto = mapper.Map<BaseUserDto>(user);
				var roles = userManager.GetRolesAsync(user).Result;
				userDto.Role = roles.FirstOrDefault()!;
				return userDto;
			})
			.ToList();

		return usersNotInOrganization;
	}
}
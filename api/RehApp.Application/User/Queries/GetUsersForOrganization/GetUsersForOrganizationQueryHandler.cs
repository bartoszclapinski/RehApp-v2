using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.DTOs;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.User.Queries.GetUsersForOrganization;

public class GetUsersForOrganizationQueryHandler(
	UserManager<ApplicationUser> userManager,
	IOrganizationRepository organizationRepository,
	IMapper mapper) : IRequestHandler<GetUsersForOrganizationQuery, IEnumerable<BaseUserDto>>
{

	public async Task<IEnumerable<BaseUserDto>> Handle(GetUsersForOrganizationQuery request, CancellationToken cancellationToken)
	{
		var organization = await organizationRepository.GetByIdWithUsersAsync(request.OrganizationId);
		if (organization is null) throw new Exception("Organization not found");
		
		organization.UserOrganizations ??= new List<UserOrganization>();
		var users = organization.UserOrganizations.Select(uo => uo.User).ToList();
		
		var userDtos = users.Select(user =>
		{
			var userDto = mapper.Map<BaseUserDto>(user);
			var roles = userManager.GetRolesAsync(user).Result;
			userDto.Role = roles.FirstOrDefault()!;
			return userDto;
		}).ToList();

		return userDtos;
	}
}
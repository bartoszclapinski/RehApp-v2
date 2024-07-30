using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.User.DTOs;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Organization.Queries.GetUsersAsOrganizationAdmins;

public class GetUsersAsOrganizationAdminsQueryHandler(
	IOrganizationRepository organizationRepository,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetUsersAsOrganizationAdminsQuery, IEnumerable<BaseUserDto>>
{

	public async Task<IEnumerable<BaseUserDto>> Handle(GetUsersAsOrganizationAdminsQuery request, CancellationToken cancellationToken)
	{
		var organizationUsers = await organizationRepository.GetUsersByOrganizationId(request.OrganizationId);
		var organizationAdmins = new List<ApplicationUser>();
		
		foreach (ApplicationUser user in organizationUsers)
			if (await userManager.IsInRoleAsync(user, "OrganizationAdmin"))
				organizationAdmins.Add(user);
		
		var users = mapper.Map<IEnumerable<BaseUserDto>>(organizationAdmins);

		return users;
	}
}
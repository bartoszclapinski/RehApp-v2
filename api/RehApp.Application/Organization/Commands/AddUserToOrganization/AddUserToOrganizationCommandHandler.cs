using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.DTOs;
using RehApp.Domain.Entities.Organizations;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;
using DomainOrganization = RehApp.Domain.Entities.Organizations.Organization;

namespace RehApp.Application.Organization.Commands.AddUserToOrganization;

public class AddUserToOrganizationCommandHandler(
	IOrganizationRepository organizationRepository,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<AddUserToOrganizationCommand, UserOrganizationDto>
{

	public async Task<UserOrganizationDto> Handle(AddUserToOrganizationCommand request, CancellationToken cancellationToken)
	{
		ApplicationUser? user = await userManager.FindByIdAsync(request.UserId);
		if (user is null) throw new Exception("User not found");
		
		DomainOrganization? organization = await organizationRepository.GetByIdAsync(request.OrganizationId);
		if (organization is null) throw new Exception("Organization not found");
		
		organization.UserOrganizations ??= new List<UserOrganization>();
		
		if (organization.UserOrganizations!.Any(uo => uo.UserId == request.UserId))
			throw new Exception("User is already in organization");
		
		var userOrganization = new UserOrganization
		{
			OrganizationId = request.OrganizationId,
			UserId = request.UserId
		};
		
		organization.UserOrganizations.Add(userOrganization);
		await organizationRepository.SaveChangesAsync();

		return new UserOrganizationDto
		{
			OrganizationId = organization.Id,
			OrganizationName = organization.Name,
			UserId = user.Id,
			UserName = user.UserName!
		};
	}
}
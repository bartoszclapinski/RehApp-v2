using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using RehApp.Domain.Interfaces;
using DomainOrganization = RehApp.Domain.Entities.Organizations.Organization;

namespace RehApp.Application.Organization.Commands.UpdateOrganization;

public class UpdateOrganizationCommandHandler(
	IOrganizationRepository organizationRepository,
	IMapper mapper,
	IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateOrganizationCommand>
{
	public async Task Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
	{
		var currentUser = httpContextAccessor.HttpContext?.User 
		                  ?? throw new InvalidOperationException("User context is not available");
		var currentUserId = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
		var isAdmin = currentUser.IsInRole("Admin");
		var isOrganizationAdmin = currentUser.IsInRole("OrganizationAdmin");
		
		DomainOrganization? organization = await organizationRepository.GetByIdAsync(request.Id);
		if (organization is null) throw new Exception("Organization not found");
		
		if (!isAdmin && !isOrganizationAdmin && organization.UserOrganizations!.All(uo => uo.UserId != currentUserId))
			throw new UnauthorizedAccessException("You are not authorized to update this organization.");
		
		mapper.Map(request, organization);
		await organizationRepository.SaveChangesAsync();
	}
}
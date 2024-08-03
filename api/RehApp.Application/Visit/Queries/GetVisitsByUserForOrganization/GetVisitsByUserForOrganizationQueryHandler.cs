using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.DTOs.VisitDTOs;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Visit.Queries.GetVisitsByUserForOrganization;

public class GetVisitsByUserForOrganizationQueryHandler(
	IVisitRepository visitRepository,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetVisitsByUserForOrganizationQuery, IEnumerable<VisitForListDto>>
{
	public async Task<IEnumerable<VisitForListDto>> Handle(GetVisitsByUserForOrganizationQuery request, CancellationToken cancellationToken)
	{
		var visits = await visitRepository.GetVisitsByUserForOrganizationAsync(request.UserId, request.OrganizationId);
		var visitDtos = new List<VisitForListDto>();

		foreach (var visit in visits)
		{
			var visitDto = mapper.Map<VisitForListDto>(visit);
			ApplicationUser? user = await userManager.FindByIdAsync(visit.CreatedByUserId);
			var roles = await userManager.GetRolesAsync(user!);
			visitDto.User.Role = roles.FirstOrDefault() ?? "No Role";
			visitDtos.Add(visitDto);
		}

		return visitDtos;
	}
}
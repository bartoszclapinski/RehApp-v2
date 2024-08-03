using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.DTOs.VisitDTOs;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Visit.Queries.GetAllVisitsForOrganization;

public class GetAllVisitsForOrganizationQueryHandler(
	IVisitRepository visitRepository,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetAllVisitsForOrganizationQuery, IEnumerable<VisitForListDto>>
{
	public async Task<IEnumerable<VisitForListDto>> Handle(GetAllVisitsForOrganizationQuery request, CancellationToken cancellationToken)
	{
		var visits = await visitRepository.GetAllVisitsForOrganizationAsync(request.OrganizationId);
		var visitDtos = new List<VisitForListDto>();

		foreach (var visit in visits)
		{
			var visitDto = mapper.Map<VisitForListDto>(visit);
			var user = await userManager.FindByIdAsync(visit.CreatedByUserId);
			var roles = await userManager.GetRolesAsync(user);
			visitDto.User.Role = roles.FirstOrDefault() ?? "No Role";
			visitDtos.Add(visitDto);
		}

		return visitDtos;
	}
}
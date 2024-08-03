using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RehApp.Application.DTOs.VisitDTOs;
using RehApp.Domain.Entities.Users;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Visit.Queries.GetVisitsByPatientIdForUser;

public class GetVisitsByPatientIdForUserQueryHandler(
	IVisitRepository visitRepository,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IRequestHandler<GetVisitsByPatientIdForUserQuery, IEnumerable<VisitForListDto>>
{
	public async Task<IEnumerable<VisitForListDto>> Handle(GetVisitsByPatientIdForUserQuery request, CancellationToken cancellationToken)
	{
		var visits = await visitRepository.GetVisitsByPatientIdForUserAsync(request.PatientId, request.UserId);
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
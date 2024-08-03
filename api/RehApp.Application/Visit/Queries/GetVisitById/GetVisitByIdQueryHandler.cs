using AutoMapper;
using MediatR;
using RehApp.Application.DTOs;
using RehApp.Application.DTOs.VisitDTOs;
using RehApp.Domain.Interfaces;

namespace RehApp.Application.Visit.Queries.GetVisitById;

public class GetVisitByIdQueryHandler(
	IVisitRepository visitRepository,
	IMapper mapper) : IRequestHandler<GetVisitByIdQuery, VisitDto>
{

	public async Task<VisitDto> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
	{
		var visit = await visitRepository.GetByIdAsync(request.Id);
		if (visit is null) throw new Exception("Visit not found");

		return mapper.Map<VisitDto>(visit);
	}
}
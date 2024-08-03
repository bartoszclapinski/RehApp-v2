using MediatR;
using RehApp.Application.DTOs;
using RehApp.Application.DTOs.VisitDTOs;

namespace RehApp.Application.Visit.Queries.GetVisitById;

public class GetVisitByIdQuery(Guid id) : IRequest<VisitDto>
{
	public Guid Id { get; set; } = id;
}
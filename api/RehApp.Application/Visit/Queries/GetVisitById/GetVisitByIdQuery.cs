using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Visit.Queries.GetVisitById;

public class GetVisitByIdQuery(Guid id) : IRequest<VisitDto>
{
	public Guid Id { get; set; } = id;
}
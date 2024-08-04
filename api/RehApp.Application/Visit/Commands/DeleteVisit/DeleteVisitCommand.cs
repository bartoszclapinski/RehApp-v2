using MediatR;

namespace RehApp.Application.Visit.Commands.DeleteVisit;

public class DeleteVisitCommand : IRequest
{
	public Guid Id { get; set; }
}
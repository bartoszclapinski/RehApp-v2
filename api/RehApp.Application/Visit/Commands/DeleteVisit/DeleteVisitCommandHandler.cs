using MediatR;
using RehApp.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RehApp.Application.Visit.Commands.DeleteVisit;

public class DeleteVisitCommandHandler(
	IVisitRepository visitRepository) : IRequestHandler<DeleteVisitCommand>
{
	public async Task Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
	{
		var visit = await visitRepository.GetByIdOnlyVisitAsync(request.Id);
		if (visit is null) throw new Exception($"Visit with id: {request.Id} not found");

		await visitRepository.DeleteAsync(visit);
		
	}
}
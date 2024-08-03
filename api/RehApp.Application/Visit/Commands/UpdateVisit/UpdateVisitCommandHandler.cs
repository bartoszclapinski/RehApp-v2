using AutoMapper;
using MediatR;
using RehApp.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RehApp.Application.Visit.Commands.UpdateVisit;

public class UpdateVisitCommandHandler(
	IVisitRepository visitRepository,
	IMapper mapper) : IRequestHandler<UpdateVisitCommand>
{
	public async Task Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
	{
		var visit = await visitRepository.GetByIdAsync(request.Id);
		if (visit is null) throw new Exception("Visit not found");

		mapper.Map(request, visit);
		await visitRepository.UpdateAsync(visit);
	}
}
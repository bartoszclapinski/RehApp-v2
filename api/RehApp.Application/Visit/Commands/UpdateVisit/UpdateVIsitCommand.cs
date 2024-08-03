using MediatR;
using System;

namespace RehApp.Application.Visit.Commands.UpdateVisit;

public class UpdateVisitCommand : IRequest
{
	public Guid Id { get; set; }
	public DateTime Date { get; set; }
	public string Description { get; set; } = default!;
}
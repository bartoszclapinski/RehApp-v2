// RehApp.Application/Visit/Commands/CreateVisit/CreateVisitCommand.cs
using MediatR;
using System;

namespace RehApp.Application.Visit.Commands.CreateVisit;

public record CreateVisitCommand : IRequest<Guid>
{
	public DateTime Date { get; init; }
	public string Description { get; init; }
	public string CreatedByUserId { get; init; }
	public Guid PatientId { get; init; }
	public Guid OrganizationId { get; init; }
}
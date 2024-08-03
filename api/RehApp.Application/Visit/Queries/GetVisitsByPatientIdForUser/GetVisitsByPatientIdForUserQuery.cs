using MediatR;
using RehApp.Application.DTOs.VisitDTOs;

namespace RehApp.Application.Visit.Queries.GetVisitsByPatientIdForUser;

public class GetVisitsByPatientIdForUserQuery : IRequest<IEnumerable<VisitForListDto>>
{
	public Guid PatientId { get; set; } = default!;
	public string UserId { get; set; } = default!;
}
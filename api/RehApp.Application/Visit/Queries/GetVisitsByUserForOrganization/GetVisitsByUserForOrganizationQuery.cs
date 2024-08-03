using MediatR;
using RehApp.Application.DTOs;
using RehApp.Application.DTOs.VisitDTOs;

namespace RehApp.Application.Visit.Queries.GetVisitsByUserForOrganization;

public class GetVisitsByUserForOrganizationQuery : IRequest<IEnumerable<VisitForListDto>>
{
	public string UserId { get; set; } = default!;
	public Guid OrganizationId { get; set; }
}
using MediatR;
using RehApp.Application.DTOs.VisitDTOs;

namespace RehApp.Application.Visit.Queries.GetAllVisitsForOrganization;

public class GetAllVisitsForOrganizationQuery : IRequest<IEnumerable<VisitForListDto>>
{
	public Guid OrganizationId { get; set; } = default!;
}
using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Queries.GetOrganizationById;

public class GetOrganizationByIdQuery(Guid organizationId) : IRequest<OrganizationDto>
{
	public Guid OrganizationId { get; set; } = organizationId;
}
using MediatR;

namespace RehApp.Application.Organization.Commands.CreateOrganization;

public class CreateOrganizationCommand : IRequest<Guid>
{
	public string Name { get; set; }
	public string Description { get; set; }
	public string Street { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
	public string Country { get; set; }
}
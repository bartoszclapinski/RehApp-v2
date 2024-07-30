using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.Organization.Commands.UpdateOrganization;

public class UpdateOrganizationCommand : IRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public AddressDto Address { get; set; }
}
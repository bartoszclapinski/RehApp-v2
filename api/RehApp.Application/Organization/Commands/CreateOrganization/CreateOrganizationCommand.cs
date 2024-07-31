using MediatR;

namespace RehApp.Application.Organization.Commands.CreateOrganization;

public record CreateOrganizationCommand : IRequest<Guid>
{
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public string Street { get; set; } = default!;
	public string City { get; set; } = default!;
	public string ZipCode { get; set; } = default!;
	public string Country { get; set; } = default!;
	public string Phone { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string? AdditionalInfo { get; set; }
	public string TaxNumber { get; set; } = default!;
}
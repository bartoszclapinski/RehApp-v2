namespace RehApp.Application.DTOs;

public class OrganizationDto
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public AddressDto Address { get; set; } = default!;
	public DateTime CreatedAt { get; set; }
	public string Phone { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string? AdditionalInfo { get; set; }
	public string TaxNumber { get; set; } = default!;
}
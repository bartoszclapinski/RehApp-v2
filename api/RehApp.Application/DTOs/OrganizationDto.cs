namespace RehApp.Application.DTOs;

public class OrganizationDto
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public AddressDto Address { get; set; }
	public DateTime CreatedAt { get; set; }
}
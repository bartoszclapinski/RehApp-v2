namespace RehApp.Application.DTOs;

public class BaseUserDto
{
    public string Id { get; set; }  = default!;
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public bool IsActive { get; set; }
    public AddressDto Address { get; set; } = default!;
    public List<UserOrganizationDto> UserOrganizations { get; set; } = default!;
    
    public string? PhoneNumber { get; set; }
    public string? Pesel { get; set; }
}

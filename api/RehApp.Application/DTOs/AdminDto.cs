namespace RehApp.Application.DTOs;

public class AdminDto : BaseUserDto
{
	public string AdminLevel { get; set; } = default!;
}
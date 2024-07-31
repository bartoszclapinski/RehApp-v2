using RehApp.Application.DTOs;

namespace RehApp.Application.User;

public interface IUserContext
{
	Task<BaseUserDto?> GetCurrentUser();
}
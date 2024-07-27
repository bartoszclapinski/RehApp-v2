using RehApp.Application.User.DTOs;

namespace RehApp.Application.User;

public interface IUserContext
{
	Task<BaseUserDto?> GetCurrentUser();
}
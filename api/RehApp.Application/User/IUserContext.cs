namespace RehApp.Application.User;

public interface IUserContext
{
	CurrentUser? GetCurrentUser();
}
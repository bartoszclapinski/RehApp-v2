namespace RehApp.Application.User;

public class CurrentUser(string Id, string Email, string Role)
{
	public bool IsInRole(string role) => Role == role;
}
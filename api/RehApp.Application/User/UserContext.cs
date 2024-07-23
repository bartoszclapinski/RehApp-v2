using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace RehApp.Application.User;


public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
	public CurrentUser? GetCurrentUser()
	{
		ClaimsPrincipal user = httpContextAccessor.HttpContext?.User 
		                       ?? throw new InvalidOperationException("User context is not available");

		if (user.Identity is not { IsAuthenticated: true }) return null;
		
		var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
		var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
		var role = user.FindFirst(c => c.Type == ClaimTypes.Role)!.Value;
		
		return new CurrentUser(userId, email, role);
	}
}
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RehApp.Application.User.DTOs;
using RehApp.Domain.Constants;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User;

public class UserContext(
	IHttpContextAccessor httpContextAccessor,
	UserManager<ApplicationUser> userManager,
	IMapper mapper) : IUserContext
{
	public async Task<BaseUserDto?> GetCurrentUser()
	{
		ClaimsPrincipal user = httpContextAccessor.HttpContext?.User 
		                       ?? throw new InvalidOperationException("User context is not available");

		if (user.Identity is not { IsAuthenticated: true }) return null;
		
		var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

		ApplicationUser? applicationUser = await userManager.FindByIdAsync(userId);
		
		if (applicationUser is null) return null;
		
		var userRole = user.FindFirst(c => c.Type == ClaimTypes.Role)?.Value;
		
		BaseUserDto? result = userRole switch
		{
			UserRoles.Doctor => mapper.Map<DoctorDto>(applicationUser),
			UserRoles.Physiotherapist => mapper.Map<DoctorDto>(applicationUser),
			UserRoles.Nurse => mapper.Map<NurseDto>(applicationUser),
			UserRoles.Admin => mapper.Map<AdminDto>(applicationUser),
			_ => mapper.Map<BaseUserDto>(applicationUser)
		};
		result.Role = userRole!;

		return result;
	}
}
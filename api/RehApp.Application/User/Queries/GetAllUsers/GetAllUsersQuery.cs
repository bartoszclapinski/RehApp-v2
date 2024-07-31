using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.User.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<BaseUserDto>>
{
	
}
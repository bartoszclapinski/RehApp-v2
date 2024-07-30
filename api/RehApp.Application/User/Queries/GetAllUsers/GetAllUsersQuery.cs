using MediatR;
using RehApp.Application.User.DTOs;

namespace RehApp.Application.User.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<GetAllApplicationUserDto>>
{
	
}
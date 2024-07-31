using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.User.Queries.GetCurrentUser;

public class GetCurrentUserQueryHandler(IUserContext userContext) : IRequestHandler<GetCurrentUserQuery, BaseUserDto?>
{

	public Task<BaseUserDto?> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
	{
		return userContext.GetCurrentUser();
	}
}
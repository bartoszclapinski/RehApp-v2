using MediatR;
using RehApp.Application.DTOs;

namespace RehApp.Application.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<BaseUserDto>
{
	public string UserId { get; set; } = default!;
}
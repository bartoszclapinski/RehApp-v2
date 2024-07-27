﻿using MediatR;
using RehApp.Application.User.DTOs;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Queries.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<BaseUserDto?>
{
	
}
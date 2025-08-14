using MediatR;
using Application.Users;

namespace Application.Users.Queries.GetUserById;


public sealed record GetUserByIdQuery(int Id) : IRequest<UserDto?>;
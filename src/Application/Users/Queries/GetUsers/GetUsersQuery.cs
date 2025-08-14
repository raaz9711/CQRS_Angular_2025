using MediatR;
using Application.Users;

namespace Application.Users.Queries.GetUsers;

public sealed record GetUsersQuery(string? Search = null, int Page = 1, int PageSize = 20)
    : IRequest<IReadOnlyList<UserDto>>;
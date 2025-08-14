using MediatR;
using Application.Common.Abstractions;
using Application.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUserById;



public sealed class GetUserByIdHandler(IAppDbContext db) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
  public Task<UserDto?> Handle(GetUserByIdQuery req, CancellationToken ct) =>
      db.Users.AsNoTracking()
        .Where(x => x.Id == req.Id)
        .Select(x => x.ToDto())
        .FirstOrDefaultAsync(ct);
}
using MediatR;
using Application.Common.Abstractions;
using Application.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUsers;


public sealed class GetUsersHandler(IAppDbContext db) : IRequestHandler<GetUsersQuery, IReadOnlyList<UserDto>>
{
    public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery req, CancellationToken ct)
    {
        var q = db.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(req.Search))
        {
            var s = req.Search.Trim();
            q = q.Where(u => u.Name.Contains(s) || u.Email.Contains(s));
        }

        var skip = Math.Max(0, (req.Page - 1) * req.PageSize);
        return await q.OrderByDescending(u => u.Id)
                      .Skip(skip).Take(req.PageSize)
                      .Select(u => u.ToDto())
                      .ToListAsync(ct);
    }
}
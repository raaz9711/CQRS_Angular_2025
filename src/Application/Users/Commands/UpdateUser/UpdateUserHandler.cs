using Application.Common.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserHandler(IAppDbContext db) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand req, CancellationToken ct)
    {
         var u = await db.Users.FirstOrDefaultAsync(x => x.Id == req.Id, ct)
                ?? throw new KeyNotFoundException("User not found.");

        var emailTaken = await db.Users.AnyAsync(x => x.Email == req.Email && x.Id != req.Id, ct);
        if (emailTaken) throw new InvalidOperationException("Email already registered.");

        u.Name = req.Name;
        u.Email = req.Email;
        u.IsActive = req.IsActive;
        u.UpdatedUtc = DateTime.UtcNow;

        await db.SaveChangesAsync(ct);
    }

}

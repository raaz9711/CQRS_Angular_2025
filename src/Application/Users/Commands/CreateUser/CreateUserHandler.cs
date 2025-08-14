using Application.Common.Abstractions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.CreateUser;

public class CreateUserHandler(IAppDbContext db) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand req, CancellationToken ct)
    {
        var emailTaken = await db.Users.AnyAsync(x => x.Email == req.Email, ct);
        if (emailTaken) throw new InvalidOperationException("Email is already registered.");

        var entity = new User { Name = req.Name, Email = req.Email, IsActive = req.IsActive };
        db.Users.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity.Id;
    }
}

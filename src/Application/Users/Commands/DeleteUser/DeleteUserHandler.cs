using Application.Common.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.DeleteUser;

public class DeleteUserHandler(IAppDbContext db) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand req, CancellationToken ct)
    {
        var entity = await db.Users.FirstOrDefaultAsync(x => x.Id == req.Id, ct)
            ?? throw new KeyNotFoundException("User not found.");
        db.Users.Remove(entity);
       await  db.SaveChangesAsync(ct);
    }
}

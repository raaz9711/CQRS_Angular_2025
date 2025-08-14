using MediatR;

namespace Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(int Id, string Name, string Email, bool IsActive) : IRequest;

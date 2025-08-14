using MediatR;

namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email, bool IsActive = true) : IRequest<int>;

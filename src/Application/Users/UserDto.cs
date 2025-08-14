namespace Application.Users;

public record UserDto(int Id, string Name, string Email, bool IsActive, DateTime CreatedUtc);

public static class UserMappings
{
    public static UserDto ToDto(this Domain.User u) =>
        new(u.Id, u.Name, u.Email, u.IsActive, u.CreatedUtc);
}

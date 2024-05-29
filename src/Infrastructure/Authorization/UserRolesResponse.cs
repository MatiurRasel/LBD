using Domain.Entities.Users;

namespace Infrastructure.Authorization;

public sealed class UserRolesResponse
{
    public Guid Id { get; init; }
    public List<Role> Roles { get; init; } = new List<Role>();
}

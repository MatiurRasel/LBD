using Domain.Entities.Abstractions;
using Domain.Entities.Users.ValueObjects;

namespace Domain.Entities.Users;
public sealed class User : Entity<UserId>
{
    private User() { }

    public string IdentityId { get; private set; } = string.Empty;
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
}

using Application.Abstractions.Messaging;

namespace Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password) : ICommand<AccessTokenResponse>;

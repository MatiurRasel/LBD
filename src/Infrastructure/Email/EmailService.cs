using Application.Abstractions.Email;

namespace Infrastructure.Email;
internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Entities.Users.ValueObjects.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}

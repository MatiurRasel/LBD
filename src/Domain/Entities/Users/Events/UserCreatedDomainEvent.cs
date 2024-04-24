using Domain.Entities.Abstractions;

namespace Domain.Entities.Users.Events;
public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;

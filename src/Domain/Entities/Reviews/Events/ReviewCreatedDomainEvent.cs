using Domain.Entities.Abstractions;

namespace Domain.Entities.Reviews.Events;
public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId) : IDomainEvent;

using Domain.Entities.Abstractions;

namespace Domain.Entities.Bookings.Events;

public sealed record BookingCompletedDomainEvent(BookingId BookingId) : IDomainEvent;

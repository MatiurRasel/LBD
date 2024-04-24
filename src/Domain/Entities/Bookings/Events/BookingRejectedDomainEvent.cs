using Domain.Entities.Abstractions;

namespace Domain.Entities.Bookings.Events;

public sealed record BookingRejectedDomainEvent(BookingId BookingId) : IDomainEvent;

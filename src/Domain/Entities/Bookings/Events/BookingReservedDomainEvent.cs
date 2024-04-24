using Domain.Entities.Abstractions;

namespace Domain.Entities.Bookings.Events;

public sealed record BookingReservedDomainEvent(BookingId BookingId) : IDomainEvent;

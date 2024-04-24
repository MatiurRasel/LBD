using Domain.Entities.Abstractions;

namespace Domain.Entities.Bookings.Events;
public sealed record BookingCancelledDomainEvent(BookingId BookingId) : IDomainEvent;


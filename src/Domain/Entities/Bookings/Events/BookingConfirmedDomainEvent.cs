using Domain.Entities.Abstractions;

namespace Domain.Entities.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(BookingId BookingId) : IDomainEvent;

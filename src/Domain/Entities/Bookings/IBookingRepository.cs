using Domain.Entities.Apartments;
using Domain.Entities.Bookings.ValueObjects;

namespace Domain.Entities.Bookings;
public interface IBookingRepository
{
    Task<Booking> GetByIdAsync(BookingId id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);

    void Add(Booking booking);
}

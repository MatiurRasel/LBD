using Domain.Entities.Apartments;
using Domain.Entities.Bookings;
using Domain.Entities.Bookings.Enums;
using Domain.Entities.Bookings.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class BookingRepository : Repository<Booking, BookingId>, IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Booking>()
            .AnyAsync(booking =>
                        booking.ApartmentId == apartment.Id &&
                        booking.Duration.Start == duration.Start &&
                        booking.Duration.End == duration.End &&
                        ActiveBookingStatuses.Contains(booking.Status),
                    cancellationToken);
    }
}

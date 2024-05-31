
using Domain.Entities.Apartments;
using Domain.Entities.Bookings;
using Domain.Entities.Reviews;
using Domain.Entities.Reviews.ValueObjects;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(reviewId => reviewId.Value, value => new ReviewId(value));

        builder.Property(review => review.Rating)
            .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

        builder.Property(x => x.Comment)
            .HasMaxLength(200);

        builder.HasOne<Apartment>()
            .WithMany()
            .HasForeignKey(x => x.ApartmentId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.HasOne<Booking>()
            .WithMany()
            .HasForeignKey(x => x.BookingId);
    }
}

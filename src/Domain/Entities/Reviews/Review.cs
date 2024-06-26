﻿using Domain.Entities.Abstractions;
using Domain.Entities.Apartments;
using Domain.Entities.Bookings;
using Domain.Entities.Bookings.Enums;
using Domain.Entities.Reviews.Events;
using Domain.Entities.Reviews.ValueObjects;
using Domain.Entities.Users;

namespace Domain.Entities.Reviews;
public class Review : Entity<ReviewId>
{
    private Review(
        ReviewId id,
        ApartmentId apartmentId,
        BookingId bookingId,
        UserId userId,
        Rating rating,
        string comment,
        DateTime createdOnUtc) : base(id)
    {
        ApartmentId = apartmentId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    protected Review() { }

    public ApartmentId ApartmentId { get; private set; }

    public BookingId BookingId { get; private set; }

    public UserId UserId { get; private set; }

    public Rating Rating { get; private set; }

    public string Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Review> Create(
        Booking booking,
        Rating rating,
        string comment,
        DateTime createdOnUtc)
    {
        if (booking.Status != BookingStatus.Completed)
            return Result.Failure<Review>(ReviewErrors.NotEligible);

        var review = new Review(
            ReviewId.New(),
            booking.ApartmentId,
            booking.Id,
            booking.UserId,
            rating,
            comment,
            createdOnUtc);

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}

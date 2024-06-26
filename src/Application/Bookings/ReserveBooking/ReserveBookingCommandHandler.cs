﻿using Application.Abstractions.Clock;
using Application.Abstractions.Messaging;
using Application.Exceptions;
using Domain.Entities.Abstractions;
using Domain.Entities.Apartments;
using Domain.Entities.Bookings;
using Domain.Entities.Bookings.ValueObjects;
using Domain.Entities.Users;
using System.Data;

namespace Application.Bookings.ReserveBooking;

public sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;
    private readonly IDateTimeProvider _dateProvider;
    public ReserveBookingCommandHandler(
        IUserRepository userRepository,
        IApartmentRepository apartmentRepository,
        IBookingRepository bookingRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingService,
        IDateTimeProvider dateProvider)
    {
        _userRepository = userRepository;
        _apartmentRepository = apartmentRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
        _dateProvider = dateProvider;
    }
    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(new UserId(request.UserId), cancellationToken);
        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);

        var apartment = await _apartmentRepository.GetByIdAsync(new ApartmentId(request.ApartmentId), cancellationToken);
        if (apartment is null)
            return Result.Failure<Guid>(ApartmentErrors.NotFound);

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            return Result.Failure<Guid>(BookingErrors.Overlap);

        try
        {
            var booking = Booking.Reserve(
            apartment,
            user.Id,
            duration,
            _dateProvider.UtcNow,
            _pricingService);

            _bookingRepository.Add(booking);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return booking.Id.Value;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }
    }
}

using Application.Abstractions.Clock;
using Application.Abstractions.Messaging;
using Domain.Entities.Abstractions;
using Domain.Entities.Apartments;
using Domain.Entities.Bookings;
using Domain.Entities.Users;

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
    }
}

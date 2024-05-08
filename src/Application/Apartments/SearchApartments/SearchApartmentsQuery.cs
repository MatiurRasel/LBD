using Application.Abstractions.Messaging;

namespace Application.Apartments.SearchApartments;

public record SearchApartmentsQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;


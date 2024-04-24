using Domain.Entities.Abstractions;

namespace Domain.Entities.Apartments;
public static class ApartmentErrors
{
    public static readonly Error NotFound = new(
        "Property.NotFound",
        "The property with the specified identifier was not found"
        );
}

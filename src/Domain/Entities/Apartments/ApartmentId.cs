using Domain.Entities.Abstractions;
using Domain.Shared;

namespace Domain.Entities.Apartments;

public record ApartmentId(Guid Value)
{
    public static ApartmentId New() => new(Guid.NewGuid());
}

//Components
//Value Property:
//Represents the underlying unique identifier value(Guid) for the apartment entity.
//Factory Method(New):
//Provides a convenient way to generate a new instance of ApartmentId with a newly generated GUID value.

//Purpose
//Identifier Encapsulation: Encapsulates the unique identifier of an apartment within a single object, providing a clear abstraction.
//Immutability: Being a record, instances of ApartmentId are immutable after creation, ensuring their values cannot be changed.
//Value Semantics: Utilizes value semantics to compare ApartmentId instances based on their underlying GUID values.
//Domain Modeling: Fits well within domain-driven design (DDD) principles, allowing apartment identifiers to be treated as first-class domain concepts.

//Usage
//Entity Identification: Used as the primary key or identifier property for apartment entities within the domain model.
//Equality Comparison: Allows comparison of ApartmentId instances for equality based on their GUID values.
//Persistence: Can be mapped to a database column (e.g., GUID or UUID column) to uniquely identify apartment records in a database.


//EXAMPLE
// Creating an instance of ApartmentId with a specific GUID value
//var apartmentId = new ApartmentId(Guid.NewGuid());

// Using the factory method to generate a new ApartmentId
//var newApartmentId = ApartmentId.New();
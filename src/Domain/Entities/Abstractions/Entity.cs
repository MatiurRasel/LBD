
using Domain.Entities.Users;
using Domain.Shared;

namespace Domain.Entities.Abstractions;
//The Entity<TEntityId> is an abstract base class intended for use within a domain-driven design(DDD) context.
//It encapsulates common behavior and properties for domain entities, specifically handling unique
//identifiers and domain events.

//Class Declaration
//Declares an abstract class Entity with a generic parameter TEntityId for the entity's identifier type.
//Implements the IEntity interface
public abstract class Entity<TEntityId> : IEntity
{
    //Domain Events Collection
    //Maintains a private list of domain events
    private readonly List<IDomainEvent> _domainEvents = new();

    //Constructors
    //The primary constructor initializes the Id property.
    //A protected parameterless constructor is provided,
    //likely for use by Entity Framework (EF) during migrations or object materialization.
    protected Entity(TEntityId id)
    {
        Id = id;
    }

    //EF Migration usage
    protected Entity() { }

    //Id Property
    //Represents the unique identifier for the entity.
    //It uses the init accessor to ensure it can only be set during object initialization.
    public TEntityId Id { get; init; }

    //Domain Events Methods
    //ClearDomainEvents(): Clears all recorded domain events.
    //GetDomainEvents() : Returns a read-only copy of the domain events list.
    //RaiseDomainEvent(IDomainEvent domainEvent): Adds a new domain event to the list.
    public void ClearDomainEvents() => _domainEvents.Clear();
    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);


}


//Purpose
//Base Class for Domain Entities: This class serves as a base class for all domain entities,
//ensuring they all have a unique identifier and can handle domain events.
//Domain Event Management: Provides infrastructure for managing domain events, which are critical in DDD
//for handling changes and side effects within the domain model.
//Encapsulation and Abstraction: Encapsulates common behavior and properties, promoting code reuse and
//consistency across different entity types.

//When to Use
//Domain-Driven Design (DDD): When following DDD principles, this base class can be used to ensure all
//entities conform to a common structure and behavior.
//Event-Driven Architectures: In systems where domain events are used to trigger side effects or
//communicate changes within the domain model.
//EF Core Integration: The parameterless constructor supports EF Core's requirements for object
//materialization during data retrieval operations.

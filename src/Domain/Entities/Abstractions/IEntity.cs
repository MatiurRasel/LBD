using Domain.Entities.Users;
using Domain.Shared;

namespace Domain.Entities.Abstractions;

//Interface Declaration
public interface IEntity
{
    //Methods
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    //GetDomainEvents(): Returns a read-only list of domain events associated with the entity.
    //This ensures that consumers of this interface can access the domain events but cannot modify the list directly.
    void ClearDomainEvents();
    //ClearDomainEvents(): Clears all domain events from the entity.
    //This method allows for resetting the list of domain events, typically after they have been processed.
}

//Purpose
//Standardization: Ensures that all entities in the domain model expose a consistent way to handle domain events.
//This standardization makes it easier to work with entities in a uniform manner.

//Domain Event Management: Provides methods for accessing and clearing domain events,
//which are crucial for implementing domain-driven design patterns.
//Domain events are used to capture and handle changes within the domain model,
//allowing for side effects and other behaviors to be triggered in response to these changes.

//Separation of Concerns: By defining domain event management in an interface,
//the actual implementation can be provided in a base class (such as Entity<TEntityId>) or
//in specific entity classes, promoting separation of concerns.


//When to Use
//Domain-Driven Design(DDD): When designing a domain model that uses entities and domain events,
//implementing the IEntity interface ensures that all entities conform to a standard way of managing domain events.

//Event-Driven Architectures: In systems where changes within the domain model need to trigger other actions or events,
//using this interface helps manage those events effectively.

//Codebase Consistency: To maintain consistency across a codebase,
//especially in large applications where multiple developers might be working
//on different parts of the domain model

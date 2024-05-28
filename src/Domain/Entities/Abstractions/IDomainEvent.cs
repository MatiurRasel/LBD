using Domain.Entities.Users;
using Domain.Shared;
using MediatR;

namespace Domain.Entities.Abstractions;

//The IDomainEvent interface extends the INotification interface from MediatR.
//This design integrates domain events with the MediatR library,
//enabling the use of its powerful in-process messaging and event handling capabilities

//Declares the IDomainEvent interface, which extends the INotification interface from MediatR.
//The INotification interface is a marker interface used by MediatR to identify notification messages.
public interface IDomainEvent : INotification
{
}

//Purpose
//Integration with MediatR: By extending INotification, IDomainEvent allows domain events
//to be handled using MediatR's notification handlers.
//This facilitates an in-process messaging system where different parts of the application can react
//to domain events.

//Standardization: Provides a common interface for all domain events, ensuring consistency in how
//domain events are defined and handled across the application.

//Decoupling: Promotes loose coupling between the components that raise domain events and
//those that handle them.This decoupling enhances the maintainability and testability of the codebase.


//When to Use
//Domain-Driven Design (DDD): In a DDD context, use IDomainEvent to represent events that occur within
//the domain model.These events capture significant state changes or business rule validations.

//Event-Driven Architectures: When implementing an event-driven architecture within a single process,
//integrating with MediatR allows for flexible and powerful event handling mechanisms.

//Cross-Cutting Concerns: When you need to implement cross-cutting concerns
//(like logging, auditing, or notifications) that respond to domain events without tightly coupling
//them to the domain model.
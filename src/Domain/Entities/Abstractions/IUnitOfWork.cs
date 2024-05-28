namespace Domain.Entities.Abstractions
{
    //The IUnitOfWork interface is designed to represent a unit of work pattern,
    //which is commonly used in domain-driven design (DDD) and repository pattern implementations.
    //This pattern is useful for managing transactions and ensuring data integrity across multiple operations.
    public interface IUnitOfWork
    {
        //A method to save changes asynchronously.
        //Takes an optional CancellationToken parameter for cancellation support.
        //Returns a Task<int>, where the integer typically represents the number of state entries written to the underlying database.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}


//Purpose
//Transaction Management: Ensures that multiple operations can be committed as a single transaction,
//maintaining data consistency and integrity.
//Abstraction: Provides an abstraction over the underlying data access mechanism,
//making the domain logic agnostic of the actual data access implementation.
//Unit of Work Pattern: Implements the unit of work pattern to manage database transactions efficiently.

//When to Use
//Complex Business Transactions: When need to group multiple operations into a single transaction to
//ensure all operations succeed or fail together.
//Repository Pattern: Often used in conjunction with the repository pattern to abstract data access logic.
//Asynchronous Programming: When working with asynchronous operations, to ensure changes are saved
//asynchronously, improving application responsiveness and scalability.
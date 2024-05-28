using Domain.Entities.Users;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Abstractions;

//The Result and Result<TValue> classes are part of a pattern to handle the outcomes of operations
//in a way that clearly distinguishes between success and failure. They encapsulate not just the success
//state, but also any associated errors, thus making error handling more robust and consistent.
//This approach is especially useful in applications that follow domain-driven design (DDD) principles
//or need a clear and structured way to deal with operation outcomes

public class Result
{
    //Constructor
    //Ensures that a successful result cannot have an error and a failure result must have an error.
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None) throw new InvalidOperationException();

        if (!isSuccess && error == Error.None) throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }
    //Properties
    //IsSuccess: Indicates whether the result represents a successful operation.
    public bool IsSuccess { get; }
    //IsFailure: A derived property indicating whether the result represents a failure.
    public bool IsFailure => !IsSuccess;
    //Error: Holds the error associated with the result, if any.
    public Error Error { get; }
    //Static Methods
    //Success() : Creates a Result instance representing success.
    public static Result Success() => new(true, Error.None);
    //Creates a Result instance representing failure with the given error.
    public static Result Failure(Error error) => new(false, error);
    //Creates a Result<TValue> instance representing success with a value.
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    //Creates a Result<TValue> instance representing failure with the given error.
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    //Create<TValue>(TValue? value): Creates a Result<TValue> based on whether the value is null,
    //assigning Error.NullValue if it is.
    public static Result<TValue> Create<TValue>(TValue? value) => value is null 
        ? Failure<TValue>(Error.NullValue) 
        : Success(value);

}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    //Implicit Conversion
    //Allows implicit conversion from TValue to Result<TValue> using the Create method
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}

//Purpose
//Error Handling: Provides a clear and consistent way to handle errors.
//By encapsulating errors within the result object, avoid scattering error checks throughout code.

//Function Output: Functions can return a Result or Result<TValue> to explicitly indicate
//success or failure, improving code readability and reducing the likelihood of unhandled errors.

//Domain-Driven Design: Aligns well with DDD by making the success and failure of operations explicit
//in the domain layer.


//When to Use
//Service Methods: Use in service methods that perform operations which can succeed or fail,
//especially where the success criteria are complex or require validation.

//Validation: Use for validation operations where you want to return detailed error information
//instead of throwing exceptions.

//Chaining Operations: Use in scenarios where multiple operations depend on the success of previous ones.
//Each operation can return a Result that the next operation can check before proceeding.
using Domain.Entities.Abstractions;
using Domain.Entities.Reviews.ValueObjects;

namespace Domain.Shared;


//Record Declaration
//Records are immutable reference types that provide built-in functionality for value equality

public record Currency
{
    //Static Fields
    //None, Usd, and Eur are predefined instances of the Currency record. 
    //None is marked as internal, making it accessible only within the same assembly,
    //whereas Usd and Eur are public, making them accessible from outside the assembly

    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency Bdt = new("BDT");

    //Private Constructor
    //The constructor is private to control the creation of Currency instances. It initializes the Code property
    private Currency(string code) => Code = code;

    //Public Property
    //Code is an immutable property, which can be set only during object initialization due to the init accessor.
    public string Code { get; init; }

    //Static Method
    //FromCode method allows for retrieving a Currency instance based on a string code.
    //It searches the All collection and returns the matching Currency or throws an exception if the code is invalid.
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ??
            throw new ApplicationException("The currency code is invalid");
    }

    //All is a collection of all predefined Currency instances.
    //It is defined as an IReadOnlyCollection to prevent modification
    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd, Eur, Bdt
    };
}
//Purpose

//Immutability: The Currency record is designed to be immutable.
//Once a Currency instance is created, it cannot be changed.
//This ensures that currency codes are consistent and reliable throughout the application's lifecycle.

//Type Safety: Using a Currency type instead of plain strings for currency codes enhances type safety,
//reducing the risk of errors from invalid or inconsistent codes.

//Centralized Definition: By defining all valid currency codes in one place,
//it becomes easier to manage and update the list of supported currencies.


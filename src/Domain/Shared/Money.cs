namespace Domain.Shared;

//Record Declaration
public record Money(decimal Amount, Currency Currency)
{
    //Operator Overloading
    //Defines the + operator for adding two Money instances
    public static Money operator +(Money first, Money second)
    {
        if (first.Currency != second.Currency)
            throw new InvalidOperationException("Currencies have to be equal");

        return new Money(first.Amount + second.Amount, first.Currency);
    }
    //Static Methods
    public static Money Zero() => new Money(0, Currency.None);
    //Zero(): Creates a Money instance with an amount of zero and the Currency.None.
    public static Money Zero(Currency currency) => new Money(0, currency);
    //Zero(Currency currency): Creates a Money instance with an amount of zero and the specified currency.

    //Instance Method
    public bool IsZero() => this == Zero(Currency);
    //IsZero(): Checks if the current Money instance represents a zero amount in its currency.
}

//Purpose
//Encapsulation of Monetary Values: The Money record encapsulates the amount and currency,
//providing a robust way to handle monetary values.

//Immutability: Being a record, Money is immutable, ensuring that once created,
//its state cannot be altered.This is important for financial calculations where consistency is crucial.

//Type Safety: By using a specific Currency type, it ensures that operations involving different
//currencies are handled explicitly, preventing accidental misuse.

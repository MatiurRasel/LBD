namespace Domain.Entities.Abstractions;

public record Error(string Code, string Name)
{
    //Static Predefined Errors
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Null value was provided");

}


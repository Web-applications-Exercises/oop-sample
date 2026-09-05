namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

public readonly record struct Money
{
    public decimal Amount
    {
        get;
        init
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }

    public Currency Currency
    {
        get;
        init
        {
            if (field == default)
                throw new ArgumentException("Currency is required", nameof(Currency));
            field = value;

        }
    }
    public Money() => throw new InvalidOperationException("Money must be initialized with an amount and a currency.");

    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public Money(decimal amount, string currencyCode) : this(amount, new Currency(currencyCode))
    {
        
    }
    
    public override string ToString() => $"{Amount} {Currency}";

    public Money Add(Money other)
    {
        if (Currency ==default || other.Currency == default)
            throw new InvalidOperationException("Cannot perform arithmetic operations on Money instances");

        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot add Money with different currencies");

        return new Money(Amount+ other.Amount, Currency);
    }

    public Money Multiply(int factor) => Multiply((decimal)factor);

    public Money Multiply(decimal factor)
    {
        if (Currency == default)
            throw new InvalidOperationException("Cannot perform arithmetic operations on Money instances");

        ArgumentOutOfRangeException.ThrowIfNegative(factor);
        
        return new Money(Amount * factor, Currency);
    }
    public static Money operator +(Money left, Money right) => left.Add(right);
    public static Money operator *(Money money, decimal factor) => money.Multiply(factor);
    public static Money operator *(decimal factor, Money money) => money.Multiply(factor);
    public static Money operator *(Money money, int factor) => money.Multiply(factor);
    public static Money operator *( int factor, Money money) => money.Multiply(factor);

}
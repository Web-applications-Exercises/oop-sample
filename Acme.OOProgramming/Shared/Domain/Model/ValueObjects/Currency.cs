namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

public readonly record struct Currency
{
    public string Code
    {
        get => field ?? string.Empty;

        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length != 3 || ! value.All(char.IsAsciiLetter))
                throw new ArgumentException("Currency code must be a 3-letter ISO 4217 code.", nameof(value));
            field = value.ToUpperInvariant();
        }
    }
    public Currency() => throw new InvalidOperationException("Currency code must be a 3-letter ISO 4217 code.");
    
    public Currency(string code) => Code = code;
    
    public override string ToString() => Code;
}
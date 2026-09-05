namespace Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

public class SupplierId
{
    public string Identifier
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    public SupplierId() => throw new InvalidOperationException("SupplierId cannot be created without an identifier");
    
    public SupplierId(string identifier) => Identifier = identifier;
    
    public override string ToString() => Identifier;
}
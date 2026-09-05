using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.SupplyChain.Domain.Model.Aggregates;

public class Supplier
{
    public SupplierId Id { get; }

    public string Name
    {
        get;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }

    public Address Address
    {
        get;
        init
        {
            if (value == default)
                throw new ArgumentException("Address is required", nameof(Address));
            field = value;
        }
    }

    public Supplier(SupplierId id, string name, Address address)
    {
        Id = id;
        Name = name;
        Address = address;
    }
    
    public Supplier(string identifier, string name, Address address) : 
        this(new SupplierId(identifier), name, address)
    {

    }

}

namespace ConsoleApp2.Models;

public partial record OrderItem
{
    public string Sku { get; init; } = string.Empty;
    public uint Quantity { get; init; }
    public decimal Price { get; init; }
    
    public decimal GetTotalPrice() => Quantity * Price;
    
    public static implicit operator OrderItem((uint quantity, decimal price) tuple) => new()
    {
        Sku = Guid.NewGuid().ToString(),
        Quantity = tuple.quantity,
        Price = tuple.price
    };
}


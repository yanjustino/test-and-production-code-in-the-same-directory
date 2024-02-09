using FluentAssertions;
using Xunit;

namespace ConsoleApp2.Models;

public partial record OrderItem
{
    [Theory]
    [InlineData(01, 5, 005)]
    [InlineData(05, 5, 025)]
    [InlineData(50, 5, 250)]
    [InlineData(00, 5, 000)]
    internal void get_total_price_method_should_calculate_correctly(uint quantity, decimal price, decimal expected)
    {
        OrderItem item = (quantity, price);
        
        item.Sku.Should().NotBeNull();
        item.Price.Should().Be(price);
        item.Quantity.Should().Be(quantity);
        item.GetTotalPrice().Should().Be(expected);
    }
}
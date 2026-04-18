using FluentAssertions;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enum;
using GoodHamburger.Domain.Exceptions;
using GoodHamburger.Domain.Rules;
using Xunit;

namespace GoodHamburger.Tests.Domain;

public class OrderTests
{
    [Fact]
    public void Should_Not_Allow_Two_Sandwiches()
    {
        var burger = new Product("X Burger", ProductCategory.Sandwich, 5m);
        var egg = new Product("X Egg", ProductCategory.Sandwich, 4.5m);

        var order = new Order();

        order.AddItem(new OrderItem(burger));

        var act = () => order.AddItem(new OrderItem(egg));

        act.Should().Throw<BusinessException>();
    }

}
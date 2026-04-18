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
    public void Should_Not_Allow_Two_Categories()
    {
        var product1 = new Product("X Burger", ProductCategory.Sandwich, 5m);
        var product2 = new Product("X Egg", ProductCategory.Sandwich, 4.5m);

        var order = new Order();

        order.AddItem(new OrderItem(product1));

        var act = () => order.AddItem(new OrderItem(product2));

        act.Should().Throw<BusinessException>();
    }

    [Fact]
    public void Should_Not_Allow_Two_Fries()
    {
        var fries1 = new Product("Batata frita", ProductCategory.Fries, 2m);
        var fries2 = new Product("Batata rústica", ProductCategory.Fries, 3m);

        var order = new Order();

        order.AddItem(new OrderItem(fries1));

        var act = () => order.AddItem(new OrderItem(fries2));

        act.Should().Throw<BusinessException>();
    }

    [Fact]
    public void Should_Not_Allow_Two_Drinks()
    {
        var drink1 = new Product("Refrigerante", ProductCategory.Drink, 2.5m);
        var drink2 = new Product("Suco", ProductCategory.Drink, 3m);

        var order = new Order();

        order.AddItem(new OrderItem(drink1));

        var act = () => order.AddItem(new OrderItem(drink2));

        act.Should().Throw<BusinessException>();
    }

}
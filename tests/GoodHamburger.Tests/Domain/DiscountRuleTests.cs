using FluentAssertions;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enum;
using GoodHamburger.Domain.Rules;
using Xunit;

namespace GoodHamburger.Tests.Domain;

public class DiscountRuleTests
{
    [Fact]
    public void Should_Apply_20_Percent_Discount_When_Has_Sandwich_Fries_And_Drink()
    {
        var order = new Order();

        order.AddItem(new OrderItem(
            new Product("X Burger", ProductCategory.Sandwich, 5m)));

        order.AddItem(new OrderItem(
            new Product("Batata frita", ProductCategory.Fries, 2m)));

        order.AddItem(new OrderItem(
            new Product("Refrigerante", ProductCategory.Drink, 2.5m)));

        order.ApplyDiscountRule();

        order.Subtotal.Should().Be(9.5m);
        order.PercentDiscount.Should().Be(0.20m);
        order.Discount.Should().Be(1.9m);
        order.Total.Should().Be(7.6m);
    }

    [Fact]
    public void Should_Apply_15_Percent_Discount_When_Has_Sandwich_And_Drink()
    {
        var order = new Order();

        order.AddItem(new OrderItem(
            new Product("X Burger", ProductCategory.Sandwich, 5m)));

        order.AddItem(new OrderItem(
            new Product("Refrigerante", ProductCategory.Drink, 2.5m)));

        order.ApplyDiscountRule();

        order.Subtotal.Should().Be(7.5m);
        order.PercentDiscount.Should().Be(0.15m);
        order.Discount.Should().Be(1.125m);
        order.Total.Should().Be(6.375m);
    }

    [Fact]
    public void Should_Apply_10_Percent_Discount_When_Has_Sandwich_And_Fries()
    {
        var order = new Order();

        order.AddItem(new OrderItem(
            new Product("X Burger", ProductCategory.Sandwich, 5m)));

        order.AddItem(new OrderItem(
            new Product("Batata frita", ProductCategory.Fries, 2m)));

        order.ApplyDiscountRule();

        order.Subtotal.Should().Be(7m);
        order.PercentDiscount.Should().Be(0.10m);
        order.Discount.Should().Be(0.7m);
        order.Total.Should().Be(6.3m);
    }

    [Fact]
    public void Should_Not_Apply_Discount_When_Has_Only_Sandwich()
    {
        var order = new Order();

        order.AddItem(new OrderItem(
            new Product("X Burger", ProductCategory.Sandwich, 5m)));

        order.ApplyDiscountRule();

        order.Subtotal.Should().Be(5m);
        order.PercentDiscount.Should().Be(0m);
        order.Discount.Should().Be(0m);
        order.Total.Should().Be(5m);
    }
}
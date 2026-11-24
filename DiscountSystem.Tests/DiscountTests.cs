using System;
using Xunit;

public class DiscountTests
{
    private readonly DiscountCalculator calculator =
        new DiscountCalculator(new DiscountStrategyFactory());

    [Fact]
    public void Normal_400_NoDiscount()
    {
        var order = new Order(1, 400, CustomerCategory.Normal);
        Assert.Equal(400, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Loyal_1200_DiscountAndBonus()
    {
        var order = new Order(1, 1200, CustomerCategory.Loyal);
        Assert.Equal(1090, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Loyal_1000_NoBonus()
    {
        var order = new Order(1, 1000, CustomerCategory.Loyal);
        Assert.Equal(950, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Student_1500_DiscountLimitedTo100()
    {
        var order = new Order(1, 1500, CustomerCategory.Student);
        Assert.Equal(1400, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Student_800_TenPercent()
    {
        var order = new Order(1, 800, CustomerCategory.Student);
        Assert.Equal(720, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Vip_1000_TwentyPercent()
    {
        var order = new Order(1, 1000, CustomerCategory.VIP);
        Assert.Equal(800, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Corporate_600_FifteenPercent()
    {
        var order = new Order(1, 600, CustomerCategory.Corporate);
        Assert.Equal(510, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Corporate_500_NoDiscount()
    {
        var order = new Order(1, 500, CustomerCategory.Corporate);
        Assert.Equal(500, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Corporate_300_NoDiscount()
    {
        var order = new Order(1, 300, CustomerCategory.Corporate);
        Assert.Equal(300, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Pensioner_1000_TwelvePercent()
    {
        var order = new Order(1, 1000, CustomerCategory.Pensioner);
        Assert.Equal(880, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Pensioner_150_FivePercent()
    {
        var order = new Order(1, 150, CustomerCategory.Pensioner);
        Assert.Equal(142.5, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Pensioner_200_FivePercent()
    {
        var order = new Order(1, 200, CustomerCategory.Pensioner);
        Assert.Equal(190, calculator.Calculate(order), 2);
    }

    [Fact]
    public void Factory_UnknownCategory_ThrowsException()
    {
        var factory = new DiscountStrategyFactory();
        var unknown = (CustomerCategory)99;
        Assert.Throws<ArgumentException>(() => factory.Create(unknown));
    }
}

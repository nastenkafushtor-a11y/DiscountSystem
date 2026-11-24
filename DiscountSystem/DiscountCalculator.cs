public class DiscountCalculator
{
    private readonly IDiscountStrategyFactory _factory;

    public DiscountCalculator(IDiscountStrategyFactory factory)
    {
        _factory = factory;
    }

    public double Calculate(Order order)
    {
        CustomerCategory category = order.CustomerCategory;
        IDiscountStrategy strategy = _factory.Create(category);
        return strategy.Calculate(order);
    }
}

public class LoyalDiscountStrategy : IDiscountStrategy
{
    private const double Rate = 0.95;
    private const double LargeOrderThreshold = 1000;
    private const double LargeOrderBonus = 50;

    public double Calculate(Order order)
    {
        double result = order.TotalPrice * Rate;
        if (order.TotalPrice > LargeOrderThreshold)
        {
            result = result - LargeOrderBonus;
        }
        return result;
    }
}

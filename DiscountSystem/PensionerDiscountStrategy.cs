public class PensionerDiscountStrategy : IDiscountStrategy
{
    private const double Threshold = 200;
    private const double SmallOrderRate = 0.95;
    private const double LargeOrderRate = 0.88;

    public double Calculate(Order order)
    {
        if (order.TotalPrice > Threshold)
        {
            return order.TotalPrice * LargeOrderRate;
        }
        return order.TotalPrice * SmallOrderRate;
    }
}

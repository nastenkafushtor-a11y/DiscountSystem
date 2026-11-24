public class CorporateDiscountStrategy : IDiscountStrategy
{
    private const double Threshold = 500;
    private const double Rate = 0.85;

    public double Calculate(Order order)
    {
        if (order.TotalPrice > Threshold)
        {
            return order.TotalPrice * Rate;
        }
        return order.TotalPrice;
    }
}

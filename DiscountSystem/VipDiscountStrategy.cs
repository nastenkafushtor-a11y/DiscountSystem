public class VipDiscountStrategy : IDiscountStrategy
{
    private const double Rate = 0.80;

    public double Calculate(Order order)
    {
        return order.TotalPrice * Rate;
    }
}

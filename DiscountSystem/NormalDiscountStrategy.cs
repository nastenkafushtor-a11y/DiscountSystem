public class NormalDiscountStrategy : IDiscountStrategy
{
    public double Calculate(Order order)
    {
        return order.TotalPrice;
    }
}

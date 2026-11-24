public class StudentDiscountStrategy : IDiscountStrategy
{
    private const double DiscountRate = 0.10;
    private const double MaxDiscount = 100;

    public double Calculate(Order order)
    {
        double discount = order.TotalPrice * DiscountRate;
        if (discount > MaxDiscount)
        {
            discount = MaxDiscount;
        }
        return order.TotalPrice - discount;
    }
}

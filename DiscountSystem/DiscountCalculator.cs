using System.Collections.Generic;

public class DiscountCalculator
{
    private readonly Dictionary<CustomerCategory, IDiscountStrategy>
        _strategies = new Dictionary<CustomerCategory, IDiscountStrategy>
        {
            { CustomerCategory.Normal, new NormalDiscountStrategy() },
            { CustomerCategory.Loyal, new LoyalDiscountStrategy() },
            { CustomerCategory.Student, new StudentDiscountStrategy() },
            { CustomerCategory.VIP, new VipDiscountStrategy() },
            { CustomerCategory.Corporate, new CorporateDiscountStrategy() }
        };

    public double Calculate(Order order)
    {
        return _strategies[order.CustomerCategory].Calculate(order);
    }
}

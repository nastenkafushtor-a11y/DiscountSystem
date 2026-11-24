using System;

public class DiscountStrategyFactory : IDiscountStrategyFactory
{
    public IDiscountStrategy Create(CustomerCategory category)
    {
        switch (category)
        {
            case CustomerCategory.Normal:
                return new NormalDiscountStrategy();
            case CustomerCategory.Loyal:
                return new LoyalDiscountStrategy();
            case CustomerCategory.Student:
                return new StudentDiscountStrategy();
            case CustomerCategory.VIP:
                return new VipDiscountStrategy();
            case CustomerCategory.Corporate:
                return new CorporateDiscountStrategy();
            default:
                throw new ArgumentException("Невідома категорія клієнта");
        }
    }
}

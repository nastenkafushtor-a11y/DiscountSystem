public interface IDiscountStrategyFactory
{
    IDiscountStrategy Create(CustomerCategory category);
}

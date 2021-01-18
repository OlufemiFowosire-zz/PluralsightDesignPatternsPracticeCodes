namespace CustomerDiscountCalculator
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }
}

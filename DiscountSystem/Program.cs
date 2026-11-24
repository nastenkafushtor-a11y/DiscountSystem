using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var calculator = new DiscountCalculator();

        var orders = new[]
        {
            new Order(1, 400, CustomerCategory.Normal),
            new Order(2, 1200, CustomerCategory.Loyal),
            new Order(3, 1500, CustomerCategory.Student),
            new Order(4, 1000, CustomerCategory.VIP),
            new Order(5, 600, CustomerCategory.Corporate),
            new Order(6, 300, CustomerCategory.Corporate)
        };

        foreach (var order in orders)
        {
            double price = calculator.Calculate(order);
            Console.WriteLine($"Замовлення {order.Id}: {price:F2} грн");
        }
    }
}

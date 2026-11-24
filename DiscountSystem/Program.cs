using System;

public enum CustomerCategory { Normal, Loyal, Student, VIP, Corporate }

public class Order
{
    public int Id { get; set; }
    public double TotalPrice { get; set; }
    public CustomerCategory CustomerCategory { get; set; }

    public Order(int id, double totalPrice, CustomerCategory category)
    {
        Id = id;
        TotalPrice = totalPrice;
        CustomerCategory = category;
    }
}

public class DiscountCalculator
{
    public double Calculate(Order order)
    {
        double result = 0;

        if (order.CustomerCategory == CustomerCategory.Normal)
        {
            result = order.TotalPrice;
        }
        else if (order.CustomerCategory == CustomerCategory.Loyal)
        {
            result = order.TotalPrice * 0.95;
            if (order.TotalPrice > 1000)
            {
                result = result - 50;
            }
        }
        else if (order.CustomerCategory == CustomerCategory.Student)
        {
            double discount = order.TotalPrice * 0.10;
            if (discount > 100)
            {
                discount = 100;
            }
            result = order.TotalPrice - discount;
        }
        else if (order.CustomerCategory == CustomerCategory.VIP)
        {
            result = order.TotalPrice * 0.80;
        }
        else if (order.CustomerCategory == CustomerCategory.Corporate)
        {
            if (order.TotalPrice > 500)
            {
                result = order.TotalPrice * 0.85;
            }
            else
            {
                result = order.TotalPrice;
            }
        }

        return result;
    }
}

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

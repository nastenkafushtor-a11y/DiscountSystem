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
        if (order.CustomerCategory == CustomerCategory.Normal)
        {
            return CalculateNormal(order);
        }
        else if (order.CustomerCategory == CustomerCategory.Loyal)
        {
            return CalculateLoyal(order);
        }
        else if (order.CustomerCategory == CustomerCategory.Student)
        {
            return CalculateStudent(order);
        }
        else if (order.CustomerCategory == CustomerCategory.VIP)
        {
            return CalculateVip(order);
        }
        else if (order.CustomerCategory == CustomerCategory.Corporate)
        {
            return CalculateCorporate(order);
        }
        return 0;
    }

    private double CalculateNormal(Order order)
    {
        return order.TotalPrice;
    }

    private double CalculateLoyal(Order order)
    {
        double result = order.TotalPrice * 0.95;
        if (order.TotalPrice > 1000)
        {
            result = result - 50;
        }
        return result;
    }

    private double CalculateStudent(Order order)
    {
        double discount = order.TotalPrice * 0.10;
        if (discount > 100)
        {
            discount = 100;
        }
        return order.TotalPrice - discount;
    }

    private double CalculateVip(Order order)
    {
        return order.TotalPrice * 0.80;
    }

    private double CalculateCorporate(Order order)
    {
        if (order.TotalPrice > 500)
        {
            return order.TotalPrice * 0.85;
        }
        return order.TotalPrice;
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

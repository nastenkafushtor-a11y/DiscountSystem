using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        var factory = new DiscountStrategyFactory();
        var calculator = new DiscountCalculator(factory);

        double totalPrice = ReadTotalPrice();
        CustomerCategory category = ReadCategory();
        var order = new Order(1, totalPrice, category);

        double price = calculator.Calculate(order);
        Console.WriteLine($"Сума замовлення: {order.TotalPrice:F2} грн");
        Console.WriteLine($"Сума зі знижкою: {price:F2} грн");
    }

    private static double ReadTotalPrice()
    {
        while (true)
        {
            Console.Write("Введіть суму замовлення: ");
            string input = Console.ReadLine();
            bool isNumber = double.TryParse(input, out double totalPrice);
            if (isNumber && totalPrice >= 0)
            {
                return totalPrice;
            }
            Console.WriteLine("Некоректна сума, спробуйте ще раз.");
        }
    }

    private static CustomerCategory ReadCategory()
    {
        Console.WriteLine("Оберіть категорію клієнта:");
        Console.WriteLine("1 - Звичайний");
        Console.WriteLine("2 - Постійний");
        Console.WriteLine("3 - Студент");
        Console.WriteLine("4 - VIP");
        Console.WriteLine("5 - Корпоративний");
        Console.WriteLine("6 - Пенсіонер");

        while (true)
        {
            Console.Write("Ваш вибір: ");
            string input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out int choice);
            if (isNumber && choice >= 1 && choice <= 6)
            {
                return (CustomerCategory)(choice - 1);
            }
            Console.WriteLine("Некоректний вибір, спробуйте ще раз.");
        }
    }
}

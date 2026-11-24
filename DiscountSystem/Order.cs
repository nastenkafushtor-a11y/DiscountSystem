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

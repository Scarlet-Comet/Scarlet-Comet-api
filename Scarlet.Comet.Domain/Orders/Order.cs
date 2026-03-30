namespace Scarlet.Comet.Domain.Orders;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderItem> Items { get; set; }

    public Order()
    {
        CustomerName = string.Empty;
        Items = new List<OrderItem>();
    }
}
namespace OnlineShopping.Order.Apllication.Models.OrderModels;

public class OrderModel
{
    public int OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}

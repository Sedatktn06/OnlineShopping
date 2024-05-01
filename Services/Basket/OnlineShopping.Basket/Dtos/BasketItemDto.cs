﻿namespace OnlineShopping.Basket.Dtos;

public class BasketItemDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

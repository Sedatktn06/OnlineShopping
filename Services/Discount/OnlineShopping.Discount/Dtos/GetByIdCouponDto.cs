﻿namespace OnlineShopping.Discount.Dtos;

public class GetByIdCouponDto
{
    public int CounponId { get; set; }
    public string Code { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}

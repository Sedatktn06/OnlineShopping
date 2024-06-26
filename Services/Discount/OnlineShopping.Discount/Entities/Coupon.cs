﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Discount.Entities;

public class Coupon
{
    [Key]
    public int CouponId { get; set; }
    public string Code { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}

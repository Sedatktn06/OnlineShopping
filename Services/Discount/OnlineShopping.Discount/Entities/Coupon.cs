using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Discount.Entities;

public class Coupon
{
    [Key]
    public int CounponId { get; set; }
    public string CounponName { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}

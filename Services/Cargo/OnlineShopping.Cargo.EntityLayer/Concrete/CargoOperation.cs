using OnlineShopping.Cargo.EntityLayer.Common;

namespace OnlineShopping.Cargo.EntityLayer.Concrete;

public class CargoOperation:BaseEntity
{
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime OperationDate { get; set; }
}

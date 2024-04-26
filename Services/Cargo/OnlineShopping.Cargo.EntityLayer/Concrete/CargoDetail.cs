using OnlineShopping.Cargo.EntityLayer.Common;

namespace OnlineShopping.Cargo.EntityLayer.Concrete;

public class CargoDetail : BaseEntity
{
    /// <summary>
    /// Sender information. Since it will come from MongoDb, it will receive a string value.
    /// </summary>
    public string SenderCustomer { get; set; } = string.Empty;
    /// <summary>
    /// Recipient information. Since it will come from MongoDb, it will receive a string value.
    /// </summary>
    public string ReceiverCustomer { get; set; } = string.Empty;
    /// <summary>
    /// It must be unique. Unique numbers of products
    /// </summary>
    public int Barcode { get; set; }
    /// <summary>
    /// Information about which company the cargo will be sent by
    /// </summary>
    public int CargoCompanyId { get; set; }
    public CargoCompany? CargoCompany { get; set; }
}

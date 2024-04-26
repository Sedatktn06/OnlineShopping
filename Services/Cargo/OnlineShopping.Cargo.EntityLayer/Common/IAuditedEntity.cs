namespace OnlineShopping.Cargo.EntityLayer.Common;

public interface IAuditedEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}

namespace OnlineShopping.Cargo.DtoLayer.Dtos.CargoOperationDtos;

public class UpdateCargoOperationDto:BaseDto
{
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime OperationDate { get; set; }
}

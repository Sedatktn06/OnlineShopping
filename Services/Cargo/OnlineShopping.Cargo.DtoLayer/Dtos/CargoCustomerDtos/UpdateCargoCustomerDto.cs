namespace OnlineShopping.Cargo.DtoLayer.Dtos.CargoCustomerDtos;

public class UpdateCargoCustomerDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

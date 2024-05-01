using AutoMapper;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DtoLayer.Mapping.CargoCustomerMappings;

public class CargoCustomerMapping : Profile
{
    public CargoCustomerMapping()
    {
        CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
        CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
    }
}

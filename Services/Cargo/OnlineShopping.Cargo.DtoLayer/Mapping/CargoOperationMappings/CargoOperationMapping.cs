using AutoMapper;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DtoLayer.Mapping.CargoOperationMappings;

public class CargoOperationMapping : Profile
{
    public CargoOperationMapping()
    {
        CreateMap<CargoOperation,CreateCargoOperationDto>().ReverseMap();
        CreateMap<CargoOperation,UpdateCargoOperationDto>().ReverseMap();
    }
}

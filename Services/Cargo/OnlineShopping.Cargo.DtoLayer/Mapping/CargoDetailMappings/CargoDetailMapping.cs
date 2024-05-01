using AutoMapper;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DtoLayer.Mapping.CargoDetailMappings;

public class CargoDetailMapping : Profile
{
    public CargoDetailMapping()
    {
        CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
        CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
    }
}

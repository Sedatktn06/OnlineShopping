using AutoMapper;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DtoLayer.Mapping.CargoCompanyMappings;

public class CargoCompanyMapping : Profile
{
    public CargoCompanyMapping()
    {
        CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
        CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();
    }
}

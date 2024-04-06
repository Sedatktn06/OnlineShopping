using AutoMapper;
using OnlineShopping.Catalog.Dtos.ProductDtos;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();
    }
}

using AutoMapper;
using OnlineShopping.Catalog.Dtos.ProductImageDtos;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Mapping;

public class ProductImageMapping:Profile
{
    public ProductImageMapping()
    {
        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
    }
}

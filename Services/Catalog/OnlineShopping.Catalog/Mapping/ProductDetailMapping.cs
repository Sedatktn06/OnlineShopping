using AutoMapper;
using OnlineShopping.Catalog.Dtos.ProductDetailDtos;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Mapping;

public class ProductDetailMapping:Profile
{
    public ProductDetailMapping()
    {
        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
    }
}

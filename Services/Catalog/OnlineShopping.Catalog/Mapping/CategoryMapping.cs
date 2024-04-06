using AutoMapper;
using OnlineShopping.Catalog.Dtos.CategoryDtos;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
    }
}

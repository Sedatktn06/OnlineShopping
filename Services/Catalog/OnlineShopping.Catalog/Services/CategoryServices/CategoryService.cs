using AutoMapper;
using OnlineShopping.Catalog.Dtos.CategoryDtos;
using OnlineShopping.Catalog.Entities;
using OnlineShopping.Catalog.Repository;

namespace OnlineShopping.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Category> _repository;

    public CategoryService(IMapper mapper, IRepository<Category> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        await _repository.CreateAsync(category);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _repository.DeleteAsync(c => c.CategoryId == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultCategoryDto>>(result);
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        var category = await _repository.GetByIdAsync(c => c.CategoryId == id);
        return _mapper.Map<GetByIdCategoryDto>(category);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var toUpdateCategory = _mapper.Map<Category>(updateCategoryDto);
        await _repository.UpdateAsync(toUpdateCategory, c => c.CategoryId == updateCategoryDto.CategoryId);
    }
}

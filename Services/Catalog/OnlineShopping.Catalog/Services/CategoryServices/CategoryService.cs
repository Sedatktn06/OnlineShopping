using AutoMapper;
using MongoDB.Driver;
using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Dtos.CategoryDtos;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(category);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(c => c.CategoryId == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var categories = await _categoryCollection.Find(c => true).ToListAsync();
        List<ResultCategoryDto> result = _mapper.Map<List<ResultCategoryDto>>(categories.ToList());
        return result;
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        var category = await _categoryCollection.Find<Category>(c => c.CategoryId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDto>(category);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var toUpdateCategory = _mapper.Map<Category>(updateCategoryDto);
        await _categoryCollection.FindOneAndReplaceAsync(c => c.CategoryId == updateCategoryDto.CategoryId, toUpdateCategory);
    }
}

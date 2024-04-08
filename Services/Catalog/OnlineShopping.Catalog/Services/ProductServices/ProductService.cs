using AutoMapper;
using MongoDB.Driver;
using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Dtos.ProductDtos;
using OnlineShopping.Catalog.Entities;
using OnlineShopping.Catalog.Repository;

namespace OnlineShopping.Catalog.Services.ProductServices;
public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Product> _repository;
    public ProductService(IMapper mapper, IRepository<Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _repository.CreateAsync(product);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _repository.DeleteAsync(p => p.ProductId == id);
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var product = await _repository.GetByIdAsync(p => p.ProductId == id);
        return _mapper.Map<GetByIdProductDto>(product);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var toUpdateProduct = _mapper.Map<Product>(updateProductDto);
        await _repository.UpdateAsync(toUpdateProduct, p => p.ProductId == updateProductDto.ProductId);
    }
}

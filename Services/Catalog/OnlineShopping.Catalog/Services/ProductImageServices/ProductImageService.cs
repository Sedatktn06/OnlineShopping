using AutoMapper;
using OnlineShopping.Catalog.Dtos.ProductImageDtos;
using OnlineShopping.Catalog.Entities;
using OnlineShopping.Catalog.Repository;

namespace OnlineShopping.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IRepository<ProductImage> _repository;

    public ProductImageService(IMapper mapper, IRepository<ProductImage> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(createProductImageDto);
        await _repository.CreateAsync(productImage);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _repository.DeleteAsync(pi => pi.ProductImageId == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var productImages = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultProductImageDto>>(productImages);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var productImage = await _repository.GetByIdAsync(pi => pi.ProductImageId == id);
        return _mapper.Map<GetByIdProductImageDto>(productImage);
        //return _mapper.Map<GetByIdProductImageDto>(productImage);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var toUpdateProductImage = _mapper.Map<ProductImage>(updateProductImageDto);
        await _repository.UpdateAsync(toUpdateProductImage, pi => pi.ProductImageId == updateProductImageDto.ProductImageId);
    }
}

using AutoMapper;
using OnlineShopping.Catalog.Dtos.ProductDetailDtos;
using OnlineShopping.Catalog.Entities;
using OnlineShopping.Catalog.Repository;

namespace OnlineShopping.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IRepository<ProductDetail> _repository;

    public ProductDetailService(IMapper mapper, IRepository<ProductDetail> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _repository.CreateAsync(productDetail);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _repository.DeleteAsync(pd => pd.ProductDetailId == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var productDetails = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(productDetails);   
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var productDetail = await _repository.GetByIdAsync(pd => pd.ProductDetailId == id);
        return _mapper.Map<GetByIdProductDetailDto>(productDetail);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var toUpdateProductDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _repository.UpdateAsync(toUpdateProductDetail, pd => pd.ProductDetailId == updateProductDetailDto.ProductDetailId);
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Catalog.Dtos.ProductDetailDtos;
using OnlineShopping.Catalog.Services.ProductDetailServices;

namespace OnlineShopping.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailService _ProductDetailService;

    public ProductDetailsController(IProductDetailService ProductDetailService)
    {
        _ProductDetailService = ProductDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductDetails()
    {
        var categories = await _ProductDetailService.GetAllProductDetailAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var ProductDetail = await _ProductDetailService.GetByIdProductDetailAsync(id);
        return Ok(ProductDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
        return Ok("Ürün detayı eklenmiştir.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _ProductDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı silinmiştir.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return Ok("Ürün detayı güncellenmiştir.");
    }
}

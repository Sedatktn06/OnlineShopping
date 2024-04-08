using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Catalog.Dtos.ProductImageDtos;
using OnlineShopping.Catalog.Services.ProductImageServices;

namespace OnlineShopping.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _ProductImageService;

    public ProductImagesController(IProductImageService ProductImageService)
    {
        _ProductImageService = ProductImageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductImages()
    {
        var categories = await _ProductImageService.GetAllProductImageAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var ProductImage = await _ProductImageService.GetByIdProductImageAsync(id);
        return Ok(ProductImage);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _ProductImageService.CreateProductImageAsync(createProductImageDto);
        return Ok("Ürün resmi eklenmiştir.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _ProductImageService.DeleteProductImageAsync(id);
        return Ok("Ürün resmi silinmiştir.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
        return Ok("Ürün resmi güncellenmiştir.");
    }
}

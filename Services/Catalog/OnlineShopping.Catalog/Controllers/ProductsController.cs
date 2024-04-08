using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Catalog.Dtos.ProductDtos;
using OnlineShopping.Catalog.Services.ProductServices;

namespace OnlineShopping.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _ProductService;

    public ProductsController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var categories = await _ProductService.GetAllProductAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var Product = await _ProductService.GetByIdProductAsync(id);
        return Ok(Product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _ProductService.CreateProductAsync(createProductDto);
        return Ok("Ürün eklenmiştir.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _ProductService.DeleteProductAsync(id);
        return Ok("Ürün silinmiştir.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _ProductService.UpdateProductAsync(updateProductDto);
        return Ok("Ürün güncellenmiştir.");
    }
}

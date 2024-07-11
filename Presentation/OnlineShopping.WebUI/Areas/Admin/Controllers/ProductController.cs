using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Core.Helpers;
using OnlineShopping.DtoLayer.CatalogDtos.ProductDtos;

namespace OnlineShopping.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Product")]
public class ProductController : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Ürünler";
        ViewBag.V3 = "Ürünler Listesi";
        ViewBag.V0 = "Ürün İşlemleri";

        var response = await RequestHelper.GetAsync<List<ResultProductDto>>("https://localhost:7070/api/", "Products");
        return View(response);
    }

    [HttpGet]
    [Route("CreateProduct")]
    public IActionResult CreateProduct()
    {
        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Ürünler";
        ViewBag.V3 = "Ürünler Ekleme Sayfası";
        ViewBag.V0 = "Ürün İşlemleri";
        return View();
    }

    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        var response = await RequestHelper.PostAsync<string>("https://localhost:7070/api/", "Products", createProductDto);
        if (!String.IsNullOrEmpty(response))
        {
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        return View();
    }

    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var response = await RequestHelper.DeleteAsync<string>("https://localhost:7070/api/", "Products?id=" + id);
        if (response != null)
        {
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        return View();
    }

    [Route("UpdateProduct/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Ürünler";
        ViewBag.V3 = "Ürün Güncelleme Sayfası";
        ViewBag.V0 = "Ürün İşlemleri";
        var response = await RequestHelper.GetAsync<UpdateProductDto>("https://localhost:7070/api/", "Products/" + id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }

    [Route("UpdateProduct/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var response = await RequestHelper.UpdateAsync<string>("https://localhost:7070/api/", "Products", updateProductDto);
        if (response != null)
        {
            return RedirectToAction("Index", "Products", new { area = "Admin" });
        }
        return View();
    }
}

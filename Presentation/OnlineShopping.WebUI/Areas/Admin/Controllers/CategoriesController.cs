using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopping.DtoLayer.CatalogDtos.CategoryDtos;

namespace OnlineShopping.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoriesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        #region ViewBag Variables

        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Kategoriler";
        ViewBag.V3 = "Kategori Listesi";
        ViewBag.V0 = "Kategori İşlemleri";

        #endregion

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(categories);
        }

        return View();
    }
}

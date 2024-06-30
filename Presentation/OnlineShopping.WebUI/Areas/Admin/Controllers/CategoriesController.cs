using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopping.Core.Helpers;
using OnlineShopping.DtoLayer.CatalogDtos.CategoryDtos;

namespace OnlineShopping.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
public class CategoriesController : Controller
{
    public async Task<IActionResult> Index()
    {
        #region ViewBag Variables

        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Kategoriler";
        ViewBag.V3 = "Kategori Listesi";
        ViewBag.V0 = "Kategori İşlemleri";

        #endregion

        var response = await RequestHelper.GetAsync<List<ResultCategoryDto>>("https://localhost:7070/api/", "Categories");
        return View(response);
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Kategoriler";
        ViewBag.V3 = "Kategori Ekleme Sayfası";
        ViewBag.V0 = "Kategori İşlemleri";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var response = await RequestHelper.PostAsync<CreateCategoryDto>("https://localhost:7070/api/", "Categories", createCategoryDto);
        if (response != null)
        {
            return RedirectToAction("Index", "Categories", new { area = "Admin" });
        }
        return View();
    }
}

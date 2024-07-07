using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopping.Core.Helpers;
using OnlineShopping.DtoLayer.CatalogDtos.CategoryDtos;

namespace OnlineShopping.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Categories")]
public class CategoriesController : Controller
{
    [Route("Index")]
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
    [Route("CreateCategory")]
    public IActionResult CreateCategory()
    {
        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Kategoriler";
        ViewBag.V3 = "Kategori Ekleme Sayfası";
        ViewBag.V0 = "Kategori İşlemleri";
        return View();
    }

    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var response = await RequestHelper.PostAsync<string>("https://localhost:7070/api/", "Categories", createCategoryDto);
        if (response != null)
        {
            return RedirectToAction("Index", "Categories", new { area = "Admin" });
        }
        return View();
    }

    [Route("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        var response = await RequestHelper.DeleteAsync<string>("https://localhost:7070/api/", "Categories?id=" + id);
        if (response != null)
        {
            return RedirectToAction("Index", "Categories", new { area = "Admin" });
        }
        return View();
    }

    [Route("UpdateCategory/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        ViewBag.V1 = "Ana Sayfa";
        ViewBag.V2 = "Kategoriler";
        ViewBag.V3 = "Kategori Güncelleme Sayfası";
        ViewBag.V0 = "Kategori İşlemleri";
        var response = await RequestHelper.GetAsync<UpdateCategoryDto>("https://localhost:7070/api/", "Categories/" + id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }

    [Route("UpdateCategory/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        var response = await RequestHelper.UpdateAsync<UpdateCategoryDto>("https://localhost:7070/api/", "Categories", updateCategoryDto);
        if (response != null)
        {
            return RedirectToAction("Index", "Categories", new { area = "Admin" });
        }
        return View();
    }
}

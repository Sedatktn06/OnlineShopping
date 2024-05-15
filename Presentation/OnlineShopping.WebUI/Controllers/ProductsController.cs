using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

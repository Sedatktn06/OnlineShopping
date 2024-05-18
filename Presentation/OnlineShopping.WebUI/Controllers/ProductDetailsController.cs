using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Controllers;

public class ProductDetailsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

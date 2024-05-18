using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

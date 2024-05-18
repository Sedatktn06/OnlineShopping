using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

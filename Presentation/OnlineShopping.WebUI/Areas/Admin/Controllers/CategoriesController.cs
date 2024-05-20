using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

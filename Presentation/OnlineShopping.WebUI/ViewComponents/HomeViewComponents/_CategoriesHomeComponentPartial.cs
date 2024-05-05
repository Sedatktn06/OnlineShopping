using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.HomeViewComponents;

public class _CategoriesHomeComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

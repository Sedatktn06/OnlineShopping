using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.HomeViewComponents;

public class _FeatureProductHomeComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.HomeViewComponents;

public class _FeatureHomeComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

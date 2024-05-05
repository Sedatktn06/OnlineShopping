using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.HomeViewComponents;

public class _CarouselDefaultComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

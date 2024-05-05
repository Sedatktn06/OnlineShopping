using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.HomeViewComponents;

public class _SpecialOfferComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

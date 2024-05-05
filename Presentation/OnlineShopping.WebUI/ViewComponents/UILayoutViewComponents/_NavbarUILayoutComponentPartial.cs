using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.UILayoutViewComponents;

public class _NavbarUILayoutComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

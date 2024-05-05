using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.UILayoutViewComponents;

public class _FooterUILayoutComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

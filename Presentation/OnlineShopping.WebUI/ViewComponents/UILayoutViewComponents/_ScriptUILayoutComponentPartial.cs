using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.UILayoutViewComponents;

public class _ScriptUILayoutComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

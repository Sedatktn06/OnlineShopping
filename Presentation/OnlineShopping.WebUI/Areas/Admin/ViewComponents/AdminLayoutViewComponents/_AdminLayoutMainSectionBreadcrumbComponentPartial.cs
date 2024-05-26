using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutMainSectionBreadcrumbComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.ContactViewComponents;

public class _ContactInformationComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

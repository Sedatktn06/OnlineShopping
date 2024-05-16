using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.ProductViewComponents;

public class _ProductListComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.ProductViewComponents;

public class _ProductByPriceFilterComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

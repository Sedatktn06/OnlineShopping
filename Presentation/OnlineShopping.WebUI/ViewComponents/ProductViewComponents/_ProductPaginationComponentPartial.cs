using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.ProductViewComponents;

public class _ProductPaginationComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

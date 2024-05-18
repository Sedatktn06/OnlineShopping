using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartCouponComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

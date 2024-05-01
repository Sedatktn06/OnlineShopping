using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Basket.Dtos;
using OnlineShopping.Basket.LoginServices;
using OnlineShopping.Basket.Services;

namespace OnlineShopping.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ILoginService _loginService;

    public BasketsController(IBasketService basketService, ILoginService loginService)
    {
        _basketService = basketService;
        _loginService = loginService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var values = await _basketService.GetBasket(_loginService.GetUserId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> Save(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;
        await _basketService.SaveBasket(basketTotalDto);
        return Ok("Sepetteki değişiklikler kaydedildi");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        await _basketService.DeleteBasket(_loginService.GetUserId);
        return Ok("Sepet başarıyla silindi.");
    }
}

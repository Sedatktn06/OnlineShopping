using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Discount.Dtos;
using OnlineShopping.Discount.Services;

namespace OnlineShopping.Discount.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCoupons()
    {
        var coupons = await _discountService.GetAllCouponsAsync();
        return Ok(coupons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        var coupon = await _discountService.GetByIdCoupnAsync(id);
        return Ok(coupon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
    {
        await _discountService.CreateCouponAsync(createCouponDto);
        return Ok("Kupon Oluşturuldu.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
    {
        await _discountService.UpdateCouponAsync(updateCouponDto);
        return Ok("Kupon Güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await _discountService.DeleteCouponAsync(id);
        return Ok("Kupon Silindi.");
    }
}

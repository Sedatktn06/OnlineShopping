using OnlineShopping.Discount.Dtos;

namespace OnlineShopping.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllCouponsAsync();
    Task CreateCouponAsync(CreateCouponDto createCouponDto);
    Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
    Task DeleteCouponAsync(int couponId);
    Task<GetByIdCouponDto> GetByIdCoupnAsync(int couponId);
}


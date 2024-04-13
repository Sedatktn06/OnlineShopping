using Dapper;
using OnlineShopping.Discount.Context;
using OnlineShopping.Discount.Dtos;

namespace OnlineShopping.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _dapperContext;

    public DiscountService(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteCouponAsync(int couponId)
    {
        string query = "Delete From Coupons Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        string query = "Select * From Coupons";
        using (var connection = _dapperContext.CreateConnection())
        {
            var coupons = await connection.QueryAsync<ResultCouponDto>(query);
            return coupons.ToList();
        }
    }

    public async Task<GetByIdCouponDto> GetByIdCoupnAsync(int couponId)
    {
        string query = "Select * From Coupons Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", Convert.ToInt32(couponId));
        using (var connection = _dapperContext.CreateConnection())
        {
            var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
            return coupon;
        }

    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        string query = "Update Coupons Set Code = @code, Rate = @rate, IsActive=@isActive, ValidDate=@validDate where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);
        parameters.Add("@couponId", updateCouponDto.CounponId);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}

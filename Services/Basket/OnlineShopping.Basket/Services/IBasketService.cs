using OnlineShopping.Basket.Dtos;

namespace OnlineShopping.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userID);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
}

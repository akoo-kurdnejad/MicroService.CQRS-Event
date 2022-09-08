using Basket.Api.Entities;

namespace Basket.ApplicationService.Services.Contract
{
    public interface IBasketService
    {
        Task<ShoppingCart> GetUserBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}

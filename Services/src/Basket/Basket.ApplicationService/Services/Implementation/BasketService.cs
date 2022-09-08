using Basket.Api.Entities;
using Basket.ApplicationService.Services.Contract;
using Basket.Domain.IGenericRepository;

namespace Basket.ApplicationService.Services.Implementation
{
    public class BasketService : IBasketService
    {
        #region Constarctor

        IGenericRepository<ShoppingCart> _genericRepository;

        public BasketService(IGenericRepository<ShoppingCart> genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        #endregion Constarctor

        public async Task<ShoppingCart> GetUserBasket(string userName)
        {
            var basket =  _genericRepository.GetEntitiesQuery()
                            .Where(current => current.UserName == userName)
                            .FirstOrDefault();

            return (basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            var result = _genericRepository.UpdateEntity(basket);
            await _genericRepository.SaveChangesAsync();

            return result;
        }

        public async Task DeleteBasket(string userName)
        {
            var basket = GetUserBasket(userName);

            await _genericRepository.RemoveEntity(basket.Id);
            await _genericRepository.SaveChangesAsync();
        }
    }
}

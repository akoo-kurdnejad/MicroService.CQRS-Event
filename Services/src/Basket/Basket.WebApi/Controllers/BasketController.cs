using Basket.Api.Entities;
using Basket.ApplicationService.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        #region Constractor

        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            this._basketService = basketService;
        }

        #endregion Constractor

        [HttpPost("[action]")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout(BasketCheckout basketCheckout)
        {
           
            var basket = await _basketService.GetUserBasket(basketCheckout.UserName);

            if (basket == null)
                return BadRequest();


            ///TODO Create BasketcheckoutEvent



            ///TODO Send Checkout Event To Rabbitmq

            await _basketService.DeleteBasket(basketCheckout.UserName);

            return Ok();
        }
    }
}

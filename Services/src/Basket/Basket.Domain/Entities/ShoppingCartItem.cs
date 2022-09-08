using Basket.Domain.Entities.Base;
using System.Security.Principal;

namespace Basket.Api.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public int Quantity { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}

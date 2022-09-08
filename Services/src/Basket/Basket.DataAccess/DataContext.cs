using Basket.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basket.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #region DbSet

        public DbSet<BasketCheckout> BasketCheckouts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent Api

            modelBuilder.Entity<ShoppingCartItem>()
             .HasOne(s => s.ShoppingCart)
             .WithMany(g => g.Items)
             .HasForeignKey(s => s.ShoppingCartId);

            #endregion
        }
    }
}

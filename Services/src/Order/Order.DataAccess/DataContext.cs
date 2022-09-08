using Microsoft.EntityFrameworkCore;

namespace Order.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #region DbSet

        public DbSet<Ordering.Domain.Entities.Order> Orders { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

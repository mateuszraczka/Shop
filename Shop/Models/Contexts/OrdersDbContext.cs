using Microsoft.EntityFrameworkCore;

namespace Shop.Models.Contexts
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {

        }
    }
}

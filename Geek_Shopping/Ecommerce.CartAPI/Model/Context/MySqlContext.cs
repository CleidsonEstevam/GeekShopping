
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.CartAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public DbSet<Product> ?Products { get; set; }
        public DbSet<CartDetail>? CartDetails { get; set; }
        public DbSet<CartHeader>? CartHaders { get; set; }
    }
}

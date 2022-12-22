using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<CouponVo> Coupons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CouponVo>().HasData(new CouponVo
            {
                Id = 1,
                CouponCode = "GEEKTESTE",
                DiscountAmount = 10
            });

            modelBuilder.Entity<CouponVo>().HasData(new CouponVo
            {
                Id = 2,
                CouponCode = "GEEKTESTE2",
                DiscountAmount = 20
            });
        }
    }
}

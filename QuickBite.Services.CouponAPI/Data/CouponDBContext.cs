using Microsoft.EntityFrameworkCore;
using QuickBite.Services.CouponAPI.Models;

namespace QuickBite.Services.CouponAPI.Data
{
    public class CouponDBContext: DbContext
    {
        public CouponDBContext(DbContextOptions<CouponDBContext> options): base(options)
        {
            
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { CouponID = 1, CouponCode = "C120", DiscountAmount = 120, MinAmount = 240, IsActive = true, CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, CreatedBy = 1, UpdatedBy = 1 },
                new Coupon { CouponID = 2, CouponCode = "C100", DiscountAmount = 100, MinAmount = 200, IsActive = true, CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, CreatedBy = 1, UpdatedBy = 1 },
                new Coupon { CouponID = 3, CouponCode = "C75", DiscountAmount = 75, MinAmount = 150, IsActive = true, CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, CreatedBy = 1, UpdatedBy = 1 },
                new Coupon { CouponID = 4, CouponCode = "C50", DiscountAmount = 50, MinAmount = 100, IsActive = true, CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, CreatedBy = 1, UpdatedBy = 1 },
                new Coupon { CouponID = 5, CouponCode = "C25", DiscountAmount = 25, MinAmount = 50, IsActive = true, CreatedDate = DateTime.Today, UpdatedDate = DateTime.Today, CreatedBy = 1, UpdatedBy = 1 }
                );
        }
    }
}

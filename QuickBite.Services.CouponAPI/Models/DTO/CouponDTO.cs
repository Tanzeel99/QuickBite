using QuickBite.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace QuickBite.Services.CouponAPI.Models.DTO
{
    public class CouponDTO
    {
        public int CouponID { get; set; }
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public bool IsActive { get; set; }
    }
}

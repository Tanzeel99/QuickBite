using QuickBite.Services.ShoppingCartAPI.Models.DTO;

namespace QuickBite.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDTO> GetCoupon(string couponCode);
    }
}

using QuickBite.Web.Models.DTO;

namespace QuickBite.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO> GetCouponByCode(string couponCode);
        Task<ResponseDTO> GetAllCoupons();
        Task<ResponseDTO> GetCouponByID(int id);
        Task<ResponseDTO> CreateCoupon(CouponDTO couponDTO);
        Task<ResponseDTO> UpdateCoupon(CouponDTO couponDTO);
        Task<ResponseDTO> DeleteCoupon(int id);
    }
}

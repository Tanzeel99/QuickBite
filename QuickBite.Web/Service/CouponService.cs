using QuickBite.Web.Models.DTO;
using QuickBite.Web.Service.IService;
using static QuickBite.Web.Utility.StaticDetails;

namespace QuickBite.Web.Service
{
    public class CouponService: ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO> CreateCoupon(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = CouponAPIBaseURL + "/api/coupon/CreateCoupon",
                Data = couponDTO,
            });
        }

        public async Task<ResponseDTO> DeleteCoupon(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.PUT,
                Url = CouponAPIBaseURL + "/api/coupon/DeleteCoupon" + id
            });
        }

        public async Task<ResponseDTO> GetAllCoupons()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBaseURL + "/api/coupon/GetAllCoupon"
            });
        }

        public async Task<ResponseDTO> GetCouponByCode(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBaseURL + "/api/coupon/GetCouponByCode/" + couponCode
            });
        }

        public async Task<ResponseDTO> GetCouponByID(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBaseURL + "/api/coupon/GetCouponById/" + id
            });
        }

        public async Task<ResponseDTO> UpdateCoupon(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.PUT,
                Url = CouponAPIBaseURL + "/api/coupon/UpdateCoupon",
                Data = couponDTO,
            });
        }
    }
}

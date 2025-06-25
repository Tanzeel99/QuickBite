using AutoMapper;
using QuickBite.Services.CouponAPI.Models;
using QuickBite.Services.CouponAPI.Models.DTO;

namespace QuickBite.Services.CouponAPI
{
    public class MappingDTOs
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
        }
    }
}

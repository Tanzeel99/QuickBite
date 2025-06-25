using AutoMapper;
using QuickBite.Services.ShoppingCartAPI.Models;
using QuickBite.Services.ShoppingCartAPI.Models.DTO;

namespace QuickBite.Services.ShoppingCartAPI
{
    public class MappingDTOs
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDTO>();
                config.CreateMap<CartHeaderDTO, CartHeader>();
                config.CreateMap<CartDetails, CartDetailsDTO>();
                config.CreateMap<CartDetailsDTO, CartDetails>();
            });
            return mappingConfig;
        }
    }
}

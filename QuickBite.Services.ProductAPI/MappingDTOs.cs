using AutoMapper;
using QuickBite.Services.ProductAPI.Models;
using QuickBite.Services.ProductAPI.Models.DTO;

namespace QuickBite.Services.ProductAPI
{
    public class MappingDTOs
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();
            });
            return mappingConfig;
        }
    }
}

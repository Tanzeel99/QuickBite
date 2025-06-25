using QuickBite.Services.ShoppingCartAPI.Models.DTO;

namespace QuickBite.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}

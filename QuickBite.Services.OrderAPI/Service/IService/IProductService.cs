using QuickBite.Services.OrderAPI.Models.DTO;

namespace QuickBite.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}

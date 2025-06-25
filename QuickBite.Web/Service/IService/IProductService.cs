using QuickBite.Web.Models.DTO;

namespace QuickBite.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDTO> GetAllProducts();
        Task<ResponseDTO> GetProductByID(int id);
        Task<ResponseDTO> CreateProduct(ProductDTO couponDTO);
        Task<ResponseDTO> UpdateProduct(ProductDTO couponDTO);
        Task<ResponseDTO> DeleteProduct(int id);
    }
}

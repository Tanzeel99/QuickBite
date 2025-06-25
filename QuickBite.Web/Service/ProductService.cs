using QuickBite.Web.Models.DTO;
using QuickBite.Web.Service.IService;
using QuickBite.Web.Utility;

namespace QuickBite.Web.Service
{
    public class ProductService: IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateProduct(ProductDTO productDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = productDto,
                Url = StaticDetails.ProductAPIBaseURL + "/api/product/CreateProduct",
                ContentType = StaticDetails.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDTO?> DeleteProduct(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductAPIBaseURL + "/api/product/DeleteProduct/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllProducts()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBaseURL + "/api/product/GetAllProduct"
            });
        }



        public async Task<ResponseDTO?> GetProductByID(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBaseURL + "/api/product/GetProductById/" + id
            });
        }

        public async Task<ResponseDTO?> UpdateProduct(ProductDTO productDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = productDto,
                Url = StaticDetails.ProductAPIBaseURL + "/api/product/UpdateProduct",
                ContentType = StaticDetails.ContentType.MultipartFormData
            });
        }
    }
}

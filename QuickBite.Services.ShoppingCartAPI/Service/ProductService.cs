using Newtonsoft.Json;
using QuickBite.Services.ShoppingCartAPI.Models.DTO;
using QuickBite.Services.ShoppingCartAPI.Service.IService;

namespace QuickBite.Services.ShoppingCartAPI.Service
{
    public class ProductService: IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

/**************************************************************************************************************************/
/*The reason this service and service in web(UI) looks is different is because we are using different way to fetch*/
/***************************************************************************************************************************/
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product/GetAllProduct");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContet);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(Convert.ToString(resp.Result));
            }
            return new List<ProductDTO>();
        }
    }
}

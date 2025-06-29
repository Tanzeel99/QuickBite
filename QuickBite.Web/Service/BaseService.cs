using QuickBite.Web.Models.DTO;
using QuickBite.Web.Service.IService;
using static QuickBite.Web.Utility.StaticDetails;
using System.Net;
using System.Text;
using Newtonsoft.Json;


namespace QuickBite.Web.Service
{
    public class BaseService : IBaseService
    {
        //to make api calls we use IHttpClientFactory
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDTO> SendAsync(RequestDTO requestDTO, bool withBearer = true)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("QuickBiteAPI");
            HttpRequestMessage message = new();

            if (requestDTO.ContentType == ContentType.MultipartFormData)
            {
                message.Headers.Add("Accept", "*/*");
            }
            else
            {
                message.Headers.Add("Accept", "application/json");
            }

            //to get and pass token 
            if (withBearer) { 
                var token = _tokenProvider.GetToken();
                message.Headers.Add("Authorization", $"Bearer {token}");
            }

            if (requestDTO.ContentType == ContentType.MultipartFormData)
            {
                var content = new MultipartFormDataContent();

                foreach (var prop in requestDTO.Data.GetType().GetProperties())
                {
                    var value = prop.GetValue(requestDTO.Data);
                    if (value is FormFile)
                    {
                        var file = (FormFile)value;
                        if (file != null)
                        {
                            content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                        }
                    }
                    else
                    {
                        content.Add(new StringContent(value == null ? "" : value.ToString()), prop.Name);
                    }
                }
                message.Content = content;
            }
            else
            {
                if (requestDTO.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
                }
            }

            message.RequestUri = new Uri(requestDTO.Url);
           
            HttpResponseMessage? apiResponse = null;
            switch (requestDTO.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post; break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put; break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete; break;
                default:
                    message.Method = HttpMethod.Get; break;
            }
            apiResponse = await httpClient.SendAsync(message);

            try
            {
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDTO() { Success = false, Message = "Not Found", Result = null };
                    case HttpStatusCode.Forbidden:
                        return new ResponseDTO() { Success = false, Message = "Access Denied", Result = null };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDTO() { Success = false, Message = "Unauthorized", Result = null };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDTO() { Success = false, Message = "Internal Server Error", Result = null };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception e)
            {

                var dto = new ResponseDTO
                {
                    Message = e.Message.ToString(),
                    Result = e,
                    Success = false,
                };
                return dto;
            }
        }
    }
}

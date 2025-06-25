using System.Security.AccessControl;
using static QuickBite.Web.Utility.StaticDetails;

namespace QuickBite.Web.Models.DTO
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}

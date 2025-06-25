using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace QuickBite.Services.ShoppingCartAPI.Utility
{

    /********************************************To pass bearer tocken with the request*****************************Video:99******************************************************/

    /*ADD 
     * builder.Services.AddHttpContextAccessor();
     * builder.Services.AddScoped<BackendApiAuthenticationHttpClientHandler>(); 
     * .AddHttpMessageHandler<BackendApiAuthenticationHttpClientHandler>() to product and coupon api in program.cs
     

     * To Uderstant more learn about DelegatingHandler in detail
     * **********************************************************************************/

    public class BackendApiAuthenticationHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _accessor;

        public BackendApiAuthenticationHttpClientHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _accessor.HttpContext.GetTokenAsync("access_token"); // fetching the token

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token); // passing the token 

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

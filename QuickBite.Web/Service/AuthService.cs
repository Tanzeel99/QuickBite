using QuickBite.Web.Models.DTO;
using QuickBite.Web.Service.IService;
using static QuickBite.Web.Utility.StaticDetails;

namespace QuickBite.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBaseURL + "/api/auth/login",
                Data = loginRequestDTO,
            }, false);
        }

        public async Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBaseURL + "/api/auth/register",
                Data = registrationRequestDTO,
            }, false);
        }

        public async Task<ResponseDTO?> AssignRoleAsyn(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = AuthAPIBaseURL + "/api/auth/assign-role",
                Data = registrationRequestDTO,
            });
        }
    }
}

using QuickBite.Web.Models.DTO;

namespace QuickBite.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseDTO?> AssignRoleAsyn(RegistrationRequestDTO registrationRequestDTO);
    }
}

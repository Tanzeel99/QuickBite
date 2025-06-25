using QuickBite.Services.AuthAPI.Models.DTO;

namespace QuickBite.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);   
        Task<string> Register(RegistrationRequestDTO regRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}

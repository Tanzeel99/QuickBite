using QuickBite.Services.AuthAPI.Models;

namespace QuickBite.Services.AuthAPI.Service.IService
{
    public interface IJWTTokenGenerator
    {
        string GenerateJWTToken(User user, IEnumerable<string> roles);
    }
}

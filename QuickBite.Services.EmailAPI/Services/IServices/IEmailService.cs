using QuickBite.Services.EmailAPI.Message;
using QuickBite.Services.EmailAPI.Models.DTO;

namespace QuickBite.Services.EmailAPI.Services.IServices
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDTO cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}

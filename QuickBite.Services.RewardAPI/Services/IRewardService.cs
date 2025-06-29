using QuickBite.Services.RewardAPI.Message;

namespace QuickBite.Services.RewardAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}

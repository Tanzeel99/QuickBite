using Microsoft.EntityFrameworkCore;
using QuickBite.Services.RewardAPI.Data;
using QuickBite.Services.RewardAPI.Message;
using QuickBite.Services.RewardAPI.Models;
using System;

namespace QuickBite.Services.RewardAPI.Services
{
    public class RewardService: IRewardService
    {
        private DbContextOptions<RewardDBContext> _dbOptions;

        public RewardService(DbContextOptions<RewardDBContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task UpdateRewards(RewardsMessage rewardsMessage)
        {
            try
            {
                Rewards rewards = new()
                {
                    OrderId = rewardsMessage.OrderId,
                    RewardsActivity = rewardsMessage.RewardsActivity,
                    UserId = rewardsMessage.UserId,
                    RewardsDate = DateTime.Now
                };
                await using var _db = new RewardDBContext(_dbOptions);
                await _db.Rewards.AddAsync(rewards);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}

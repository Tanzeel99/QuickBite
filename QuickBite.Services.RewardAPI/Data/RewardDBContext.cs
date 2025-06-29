using Microsoft.EntityFrameworkCore;
using QuickBite.Services.RewardAPI.Models;
using System;

namespace QuickBite.Services.RewardAPI.Data
{
    public class RewardDBContext: DbContext
    {
        public RewardDBContext(DbContextOptions<RewardDBContext> options) : base(options)
        {
        }

        public DbSet<Rewards> Rewards { get; set; }
    }
}

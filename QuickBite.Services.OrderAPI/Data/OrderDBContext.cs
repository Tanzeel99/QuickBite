using Microsoft.EntityFrameworkCore;
using QuickBite.Services.OrderAPI.Models;
using System;

namespace QuickBite.Services.OrderAPI.Data
{
    public class OrderDBContext: DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {
        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}

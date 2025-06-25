using Microsoft.EntityFrameworkCore;
using QuickBite.Services.ShoppingCartAPI.Models;
using System.Reflection.PortableExecutable;

namespace QuickBite.Services.ShoppingCartAPI.Data
{
    public class ShoppingCartDBContext: DbContext
    {
        public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options) : base(options)
        {

        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}

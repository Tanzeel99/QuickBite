using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using QuickBite.Services.AuthAPI.Models;

namespace QuickBite.Services.AuthAPI.Data
{
    public class AuthDBContext: IdentityDbContext<User>
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options): base(options)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

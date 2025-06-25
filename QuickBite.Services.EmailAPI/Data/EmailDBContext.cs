using Microsoft.EntityFrameworkCore;
using QuickBite.Services.EmailAPI.Models;

namespace QuickBite.Services.EmailAPI.Data
{
    public class EmailDBContext: DbContext
    {
        public EmailDBContext(DbContextOptions<EmailDBContext> options) : base(options)
        {
            
        }

        public DbSet<EmailLogger> EmailLoggers { get; set; }
    }
}

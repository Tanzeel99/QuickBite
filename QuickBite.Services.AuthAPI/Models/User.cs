using Microsoft.AspNetCore.Identity;

namespace QuickBite.Services.AuthAPI.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
    }
}

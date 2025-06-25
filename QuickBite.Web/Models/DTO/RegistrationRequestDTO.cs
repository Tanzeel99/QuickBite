using System.ComponentModel.DataAnnotations;

namespace QuickBite.Web.Models.DTO
{
    public class RegistrationRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}

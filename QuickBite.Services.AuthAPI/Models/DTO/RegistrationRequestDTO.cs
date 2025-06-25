namespace QuickBite.Services.AuthAPI.Models.DTO
{
    public class RegistrationRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}

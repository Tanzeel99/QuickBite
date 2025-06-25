namespace QuickBite.Services.AuthAPI.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; } = "Success!";
    }
}

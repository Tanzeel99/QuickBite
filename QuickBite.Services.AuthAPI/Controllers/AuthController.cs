using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBite.Services.AuthAPI.Models.DTO;
using QuickBite.Services.AuthAPI.Service.IService;

namespace QuickBite.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDTO _responseDTO;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _responseDTO = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _authService.Login(model);

            if (loginResponse.User == null)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = "Username or Password incorrect.";
                return BadRequest(_responseDTO);
            }

            _responseDTO.Result = loginResponse;
            return Ok(_responseDTO);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            var errorMessage = await _authService.Register(model);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                _responseDTO.Success = false;
                _responseDTO.Message = errorMessage;
                return BadRequest(_responseDTO);
            }

            return Ok(_responseDTO);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> Role([FromBody] RegistrationRequestDTO model)
        {
            var isSuccess = await _authService.AssignRole(model.Email, model?.Role.ToUpper());

            if (!isSuccess)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = "An error occurred while assigning the role.";
                return BadRequest(_responseDTO);
            }

            return Ok(_responseDTO);
        }
    }
}

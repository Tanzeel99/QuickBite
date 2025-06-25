using Microsoft.AspNetCore.Identity;
using QuickBite.Services.AuthAPI.Data;
using QuickBite.Services.AuthAPI.Models;
using QuickBite.Services.AuthAPI.Models.DTO;
using QuickBite.Services.AuthAPI.Service.IService;

namespace QuickBite.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthDBContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTTokenGenerator _jWTTokenGenerator;

        public AuthService(AuthDBContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJWTTokenGenerator jWTTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jWTTokenGenerator = jWTTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.Users.FirstOrDefault(a => a.Email.ToLower() == email.ToLower());

            if (user != null) {

                //.GetAwaiter().GetResult() if we want to avaoid await keyword 
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //create role if role not exist

                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);  
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.Users.FirstOrDefault(a=>a.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (!isValid || user is null) {
                return new LoginResponseDTO
                {
                    Token = "",
                    User = null
                };
            }

            //If user was found, Generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);

            var token = _jWTTokenGenerator.GenerateJWTToken(user, roles);

            UserDTO userDTO = new UserDTO
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                ContactNo = user.PhoneNumber
            };

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO
            {
                Token = token,
                User = userDTO,
            };

            return loginResponseDTO;
        }

        public async Task<string> Register(RegistrationRequestDTO regRequestDTO)
        {
            User user = new User
            {
                UserName = regRequestDTO.Email,
                Email = regRequestDTO.Email,
                NormalizedEmail = regRequestDTO.Email.ToUpper(),
                Name = regRequestDTO.Name,
                PhoneNumber = regRequestDTO.ContactNo
            };

            try
            {
                var result = await _userManager.CreateAsync(user, regRequestDTO.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _db.Users.First(a=>a.UserName == regRequestDTO.Email);

                    UserDTO userDTO = new UserDTO
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        ContactNo = userToReturn.PhoneNumber
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

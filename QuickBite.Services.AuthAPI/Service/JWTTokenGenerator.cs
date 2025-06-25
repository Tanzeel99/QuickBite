using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuickBite.Services.AuthAPI.Models;
using QuickBite.Services.AuthAPI.Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickBite.Services.AuthAPI.Service
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        //To fetch jwt details from app settings which was mapped with JWTOptios class created
        private readonly JWTOptios _jWTOptios;
        public JWTTokenGenerator(IOptions<JWTOptios> jWTOptios)
        {
            _jWTOptios = jWTOptios.Value;
        }

        public string GenerateJWTToken(User user, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jWTOptios.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            };

            //Adding roles in claims
            claims.AddRange(roles.Select(a=> new Claim(ClaimTypes.Role, a)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jWTOptios.Audience,
                Issuer = _jWTOptios.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using RequestTracker.Models;
using RequestTracker.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RequestTracker.Services
{
    public class TokenService : ITokenService
    {

        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;


        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }

        public string GenerateToken(Employee employee)
        {
            var claims = new List<Claim>(){
                new(ClaimTypes.Name, employee.Id.ToString()),
                new(ClaimTypes.Role, employee.Role)
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(myToken);
        }
    }
}

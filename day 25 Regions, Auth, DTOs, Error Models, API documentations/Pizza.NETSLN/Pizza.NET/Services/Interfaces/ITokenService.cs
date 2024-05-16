using Pizza.NET.Models;

namespace Pizza.NET.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}

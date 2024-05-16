using RequestTracker.Models;

namespace RequestTracker.Services
{
    public interface ITokenService

    {
        public string GenerateToken(Employee employee);

    }
}

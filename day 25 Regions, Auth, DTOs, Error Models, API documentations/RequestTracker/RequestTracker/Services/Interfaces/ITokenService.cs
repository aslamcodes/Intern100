using RequestTracker.Models;

namespace RequestTracker.Services.Interfaces
{
    public interface ITokenService

    {
        public string GenerateToken(Employee employee);

    }
}

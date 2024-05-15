using Pizza.NET.Models.DTO;

namespace Pizza.NET.Services.Interfaces
{
    public interface IUserAuthService
    {
        Task<Models.User> Register(UserRegisterDTO userRegisterDTO);

        Task<Models.User> Login(UserLoginDTO userLoginDTO);
    }
}

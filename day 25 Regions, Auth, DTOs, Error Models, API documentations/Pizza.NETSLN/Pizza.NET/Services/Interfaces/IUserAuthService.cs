using Pizza.NET.Models.DTO;

namespace Pizza.NET.Services.Interfaces
{
    public interface IUserAuthService
    {
        Task<AuthReturnDto> Register(UserRegisterDTO userRegisterDTO);

        Task<AuthReturnDto> Login(UserLoginDTO userLoginDTO);
    }
}

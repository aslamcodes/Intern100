using RequestTracker.Controllers;
using RequestTracker.Models.DTO;

namespace RequestTracker.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> IsEnabled(int requestRaisedBy);
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<EmployeeReturnDto> Register(EmployeeRegisterDto employeeDTO);
        public Task<ActivateEmployeeReturnDto> ActivateUser(ActivateUserDto employeeDetails);


    }
}

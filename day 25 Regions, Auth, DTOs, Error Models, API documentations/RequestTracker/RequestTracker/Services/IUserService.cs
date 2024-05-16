using RequestTracker.Models;
using RequestTracker.Models.DTO;

namespace RequestTracker.Services
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);

    }
}

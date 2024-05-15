using RequestTracker.Models;
using RequestTracker.Models.DTO;

namespace RequestTracker.Services
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}

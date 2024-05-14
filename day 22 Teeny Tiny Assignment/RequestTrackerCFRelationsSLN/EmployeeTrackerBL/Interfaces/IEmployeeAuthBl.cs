using Models;

namespace EmployeeTrackerBL
{
    public interface IEmployeeAuthBl
    {
        public Task<Employee> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
    }
}

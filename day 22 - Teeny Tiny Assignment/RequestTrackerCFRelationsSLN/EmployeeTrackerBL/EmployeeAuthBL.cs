using EmployeeTrackerDAL;
using Models;
using Models.Enums;

namespace EmployeeTrackerBL
{
    public class EmployeeAuthBL : IEmployeeAuthBL
    {
        private readonly IRepository<int, Employee> _repo;
        public EmployeeAuthBL()
        {
            _repo = new EmployeeRepository(new RequestTrackerContext());
        }

        public async Task<Employee> Login(Employee employee)
        {
            var repoEmployee = await _repo.Get(employee.Id);

            if (repoEmployee == null)
            {
                throw new EntityNotFoundException(EntityEnum.Employee);
            }

            if (employee.Password != repoEmployee.Password)
            {
                throw new InvalidPasswordException();
            }

            return repoEmployee;

        }

        public Task<Employee> Register(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

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
            var existingEmployee = await _repo.Get(employee.Id);

            if (existingEmployee == null)
            {
                throw new EntityNotFoundException(EntityEnum.Employee);
            }

            if (!existingEmployee.PasswordCheck(employee.Password))
            {
                throw new InvalidPasswordException();
            }

            return existingEmployee;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var existingEmployee = await _repo.Add(employee);
            // TODO: Define Employee not created Exception
            if (existingEmployee == null)
            {
                throw new EntityNotFoundException(EntityEnum.Employee);
            }

            return existingEmployee;
        }
    }
}

using EmployeeRequestTrackerDALLib;
using EmployeeRequestTrackerModelLib;

namespace EmployeeRequestTrackerBLLib
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }
    }
}

using EmployeeRequestTrackerDALLib;
using EmployeeRequestTrackerModelLib;

namespace EmployeeRequestTrackerBLLib
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepo)
        {
            _departmentRepository = departmentRepo;
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }

            throw new DuplicateDepartmentNameException();
        }


        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = GetDepartmentByName(departmentOldName);

            department.Name = departmentNewName;

            _departmentRepository.Update(department);

            return department;

        }

        public Department GetDepartmentById(int id)
        {
            var result = _departmentRepository.Get(id);

            if (result != null)
            {
                return result;
            }

            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var result = _departmentRepository.GetAll();

            foreach (var department in result)
            {
                if (department.Name == departmentName)
                {
                    return department;
                }
            }
            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);

            if (department != null)
            {
                return department.Department_Head;
            }

            throw new DepartmentHeadNotFoundException();
        }
    }
}

using System.Runtime.Serialization;

namespace EmployeeRequestTrackerBLLib
{
    public class DepartmentNotFoundException : Exception
    {
        string msg;

        public DepartmentNotFoundException()
        {
            msg = "Department not found";
        }
        public override string Message => msg;

    }
}
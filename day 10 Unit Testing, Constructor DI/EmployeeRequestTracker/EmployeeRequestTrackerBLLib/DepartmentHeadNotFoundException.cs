using System.Runtime.Serialization;

namespace EmployeeRequestTrackerBLLib
{
    internal class DepartmentHeadNotFoundException : Exception
    {
        string msg;

        public DepartmentHeadNotFoundException()
        {
            msg = "Department Head Not Found";
        }
        public override string Message => msg;
    }
}
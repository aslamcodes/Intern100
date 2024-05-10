using System.Runtime.Serialization;

namespace EmployeeRequestTrackerBLLib
{
    [Serializable]
    internal class DuplicateEmployeeException : Exception
    {
        private readonly string msg;
        public DuplicateEmployeeException()
        {
            msg = "Employee Already exists";
        }


        public override string Message => msg;

    }
}
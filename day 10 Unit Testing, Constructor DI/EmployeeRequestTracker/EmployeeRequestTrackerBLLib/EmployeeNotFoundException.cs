using System.Runtime.Serialization;

namespace EmployeeRequestTrackerBLLib
{

    internal class EmployeeNotFoundException : Exception
    {

        private readonly string Msg;
        public EmployeeNotFoundException()
        {
            Msg = "Employee not found";
        }

        public override string Message => Msg;
    }
}
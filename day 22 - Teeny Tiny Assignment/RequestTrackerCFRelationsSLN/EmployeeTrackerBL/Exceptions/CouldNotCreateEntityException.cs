using Models.Enums;

namespace EmployeeTrackerBL.Exceptions
{
    [Serializable]
    public class CouldNotCreateEntityException : Exception
    {

        private readonly string _message;
        public CouldNotCreateEntityException(EntityEnum entity)
        {
            _message = $"Could not create {entity} entity";
        }

        override public string Message => _message;

    }
}
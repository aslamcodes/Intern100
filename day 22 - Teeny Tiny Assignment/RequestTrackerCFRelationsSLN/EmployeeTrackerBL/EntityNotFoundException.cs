using Models.Enums;

namespace EmployeeTrackerBL
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        private readonly string _message;
        public EntityNotFoundException(EntityEnum entity)
        {
            _message = $"Entity {entity} not found";
        }

        public override string Message => _message;
    }
}
using Models.Enums;

namespace EmployeeTrackerBL
{
    [Serializable]
    public class EntityNotFoundException(EntityEnum entity) : Exception
    {
        public override string Message { get; } = $"Entity {entity} not found";
    }
}
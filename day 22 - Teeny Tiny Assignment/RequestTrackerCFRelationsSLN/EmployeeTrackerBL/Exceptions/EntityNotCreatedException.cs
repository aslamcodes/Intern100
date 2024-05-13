using Models.Enums;

namespace EmployeeTrackerBL;

public class EntityNotCreatedException(EntityEnum entity) : Exception
{
    public override string Message { get; } = $"Entity {entity} not created";
}
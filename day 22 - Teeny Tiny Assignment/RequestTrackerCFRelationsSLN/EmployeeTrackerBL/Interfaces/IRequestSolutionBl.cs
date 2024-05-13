using Models;

namespace EmployeeTrackerBL;

public interface IRequestSolutionBl
{
    public Task<List<RequestSolution>> GetAllSolutions();
    public Task<List<RequestSolution>> GetAllSolutionsForUser(Employee authUser);
    public Task<RequestSolution> ProvideSolution(RequestSolution solution);
}
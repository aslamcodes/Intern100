using Microsoft.EntityFrameworkCore;
using Models;

namespace EmployeeTrackerDAL;

public class SolutionRepository(RequestTrackerContext dbContext) : IRepository<int, RequestSolution>
{
    public async Task<RequestSolution> Add(RequestSolution entity)
    {
        dbContext.RequestSolutions.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public Task<RequestSolution> Update(RequestSolution entity)
    {
        throw new NotImplementedException();
    }

    public Task<RequestSolution> Delete(int key)
    {
        throw new NotImplementedException();
    }

    public Task<RequestSolution> Get(int key)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RequestSolution>> GetAll()
    {
        var solutions = await dbContext.RequestSolutions.ToListAsync();

        return solutions;
    }
}
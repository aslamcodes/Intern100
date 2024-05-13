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

    public async Task<RequestSolution> Update(RequestSolution entity)
    {
        dbContext.RequestSolutions.Update(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<RequestSolution?> Delete(int key)
    {
        var solution = await Get(key);

        if (solution == null)
        {
            return null;
        }

        dbContext.RequestSolutions.Remove(solution);

        await dbContext.SaveChangesAsync();

        return solution;
    }

    public async Task<RequestSolution?> Get(int key)
    {
        var solution = await dbContext.RequestSolutions.FindAsync(key);

        return solution;
    }

    public async Task<List<RequestSolution>?> GetAll()
    {
        var solutions = await dbContext.RequestSolutions.ToListAsync();

        if (solutions.Count == 0)
        {
            return null;
        }

        return solutions;
    }
}
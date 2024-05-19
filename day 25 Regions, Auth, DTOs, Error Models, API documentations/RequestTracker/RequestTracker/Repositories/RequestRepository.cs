using Microsoft.EntityFrameworkCore;
using Models;
using RequestTracker.Contexts;
using RequestTracker.Repositories;

namespace EmployeeTrackerDAL;

public class RequestRepository(RequestTrackerContext context) : IRepository<int, Request>
{
    public async Task<Request> Add(Request entity)
    {
        context.Requests.Add(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<Request> Update(Request entity)
    {
        context.Requests.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<Request?> Delete(int key)
    {
        var request = await Get(key);

        if (request == null)
        {
            return null;
        }

        context.Requests.Remove(request);

        await context.SaveChangesAsync();

        return request;
    }

    public async Task<Request> Get(int key)
    {
        var request = await context.Requests.FindAsync(key);

        if (request == null)
        {
            return null;
        }

        return request;
    }

    public async Task<IEnumerable<Request>> Get()
    {
        var requests = await context.Requests.ToListAsync();

        if (requests.Count == 0)
        {
            return null;
        }

        return requests;
    }
}
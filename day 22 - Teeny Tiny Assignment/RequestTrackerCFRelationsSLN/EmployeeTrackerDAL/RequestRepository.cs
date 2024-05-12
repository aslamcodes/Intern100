using Microsoft.EntityFrameworkCore;
using Models;

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

    public async Task<Request> Delete(int key)
    {
        Request request = await Get(key);
        
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

    public async Task<IList<Request>> GetAll()
    {
        return await context.Requests.ToListAsync();
    }
}
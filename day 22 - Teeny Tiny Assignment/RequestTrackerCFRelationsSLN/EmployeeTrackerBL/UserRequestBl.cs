using EmployeeTrackerDAL;
using Models;
using Models.Enums;

namespace EmployeeTrackerBL;

public class UserRequestBl: IUserRequestBl
{
    private readonly IRepository<int, Request> _requestRepository = new RequestRepository(new RequestTrackerContext());
   


    public async Task<Request> RaiseRequest(Request entity)
    {
        var request = await _requestRepository.Add(entity);

        if (request == null)
        {
            throw new EntityNotFoundException(EntityEnum.Request);
        }

        return request;
    }

    public async Task<List<Request>> GetAllRequestForUser(Employee user)
    {
       var requests=  await _requestRepository.GetAll();

       return requests.Where(request => request.RequestRaisedBy == user.Id).ToList();
    }

    public Task<Request> ViewSolutionsForUser()
    {
        throw new NotImplementedException();
    }

    public async Task<Request> GetRequestById(int requestId)
    {
        var request = await _requestRepository.Get(requestId);
        
        return request;
    }

    public async Task<Request> MarkRequestClosed(Request request)
    {
        request.RequestStatus = "Closed";
        await _requestRepository.Update(request);
        return request;
    }
}
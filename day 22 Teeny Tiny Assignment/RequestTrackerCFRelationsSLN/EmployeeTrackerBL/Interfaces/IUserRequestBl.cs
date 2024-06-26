using Models;

namespace EmployeeTrackerBL;

public interface IUserRequestBl
{
    public Task<Request> RaiseRequest(Request request);

    public Task<List<Request>> GetAllRequestForUser(Employee user);

    public Task<Request> GetRequestById(int requestId);
    public Task<Request> MarkRequestClosed(Request request, int closedBy);
    public Task<List<Request>> GetAllRequests();
}
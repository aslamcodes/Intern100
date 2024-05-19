using RequestTracker.Models.DTO;

namespace RequestTracker.Services.Interfaces
{
    public interface IRequestService
    {
        public Task<RequestDto> RaiseRequest(CreateRequestDto request);

        public Task<List<RequestDto>> GetAllRequestForUser(int user);

        public Task<RequestDto> GetRequestById(int requestId);
        public Task<RequestDto> MarkRequestClosed(CloseRequestDto request);
        public Task<IEnumerable<RequestDto>> GetAllRequestsForAdmin();
    }
}
using Models;
using RequestTracker.Exceptions;
using RequestTracker.Models.DTO;
using RequestTracker.Repositories;
using RequestTracker.Services.Interfaces;


namespace RequestTracker.Services
{

    public class RequestService(IRepository<int, Request> _requestRepository, IUserService userService) : IRequestService
    {
        public async Task<RequestDto> RaiseRequest(CreateRequestDto entity)
        {
            try
            {
                if (!await userService.IsEnabled(entity.RequestRaisedBy))
                {
                    throw new UserNotEnabledException(entity.RequestRaisedBy);
                };


                var requestToAdd = new Request
                {
                    RequestRaisedBy = entity.RequestRaisedBy,
                    RequestDate = DateTime.Now,
                    RequestMessage = entity.Message,
                    RequestStatus = "Open"
                };

                var request = await _requestRepository.Add(requestToAdd);

                return request.ToRequestDto();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<RequestDto>> GetAllRequestForUser(int id)
        {
            var requests = await _requestRepository.Get();

            return requests != null
                ? requests.Where(request => request.RequestRaisedBy == id).Select(r => r.ToRequestDto()).ToList()
                : throw new NoRequestFoundException();
        }


        public async Task<RequestDto> GetRequestById(int requestId)
        {
            var request = await _requestRepository.Get(requestId);

            return request.ToRequestDto() ?? throw new Exception();
        }


        public async Task<RequestDto> MarkRequestClosed(CloseRequestDto closeRequest)
        {
            var request = await _requestRepository.Get(closeRequest.Id);

            request.RequestStatus = "Closed";

            request.RequestClosedBy = closeRequest.closedBy;

            await _requestRepository.Update(request);

            return request.ToRequestDto();
        }


        public async Task<IEnumerable<RequestDto>> GetAllRequestsForAdmin()
        {
            var requests = await _requestRepository.Get();

            if (requests == null)
                throw new NoRequestFoundException();

            return requests
                .OrderByDescending(r => r.RequestStatus == "Open")
                .OrderBy(r => r.RequestStatus)
                .Select(r => r.ToRequestDto());
        }
    }
}
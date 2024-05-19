using Models;

namespace RequestTracker.Models.DTO
{
    public static class DtoMapper
    {
        public static EmployeeReturnDto ToEmployeeReturnDto(this Employee employee)
        {
            return new EmployeeReturnDto
            {
                Id = employee.Id,
                DateOfBirth = employee.DateOfBirth,
                Image = employee.Image,
                Name = employee.Name,
                Phone = employee.Phone,
                Role = employee.Role
            };
        }

        public static RequestDto ToRequestDto(this Request request)
        {
            return new RequestDto
            {
                RequestClosedBy = request.RequestClosedBy,
                RequestDate = request.RequestDate,
                RequestMessage = request.RequestMessage,
                RequestRaisedBy = request.RequestRaisedBy,
                RequestStatus = request.RequestStatus,
                ClosedDate = request.ClosedDate,
                Id = request.RequestNumber

            };
        }
    }
}

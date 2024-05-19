namespace RequestTracker.Models.DTO
{
    public class RequestDto
    {

        public int Id { get; set; }

        public string RequestMessage { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        public string RequestStatus { get; set; }

        public int RequestRaisedBy { get; set; }

        public int? RequestClosedBy { get; set; }


    }
}
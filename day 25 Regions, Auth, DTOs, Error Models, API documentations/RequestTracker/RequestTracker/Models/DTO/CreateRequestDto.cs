namespace RequestTracker.Models.DTO
{
    public class CreateRequestDto
    {
        public int RequestRaisedBy { get; set; }
        public string Message { get; set; }
    }
}
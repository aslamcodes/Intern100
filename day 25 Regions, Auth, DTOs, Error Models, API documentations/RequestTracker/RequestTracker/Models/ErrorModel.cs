namespace RequestTracker.Models
{
    public class ErrorModel(string message, int code)
    {
        public string Message { get; set; } = message;

        public int Code { get; set; } = code;
    }
}

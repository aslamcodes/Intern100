namespace Pizza.NET.Models
{
    internal class ErrorModel
    {
        public string ErrorMessage { get; set; }

        public int errorCode { get; set; }

        public ErrorModel(string errorMessage, int errorCode)
        {
            ErrorMessage = errorMessage;
            this.errorCode = errorCode;
        }

    }
}
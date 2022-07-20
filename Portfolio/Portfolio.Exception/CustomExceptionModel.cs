namespace Portfolio.ExceptionHandler
{
    public class CustomExceptionModel
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public string DetailedErrorMessage { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }
}

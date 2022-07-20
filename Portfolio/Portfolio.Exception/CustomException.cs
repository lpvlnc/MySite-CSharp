namespace Portfolio.ExceptionHandler
{
    public class CustomException : Exception
    {
        private readonly string _errorMessage = "";
        private readonly string _detailedErrorMessage = "";
        private readonly int _statusCode = 500;

        public CustomException(string message, string detailedErrorMessage, int? statusCode = null)
        {
            this._errorMessage = message;
            this._detailedErrorMessage = detailedErrorMessage;
            if (statusCode.HasValue)
                this._statusCode = statusCode.Value;
        }

        public int GetStatusCode()
        {
            return this._statusCode;
        }

        public dynamic GetErrorObject()
        {
            if ((_statusCode >= 200 && _statusCode <= 210) || _statusCode == 412)
                return _errorMessage;
            else
            {
                return new CustomExceptionModel
                {
                    ErrorMessage = this._errorMessage,
                    DetailedErrorMessage = this._detailedErrorMessage,
                    StatusCode = this._statusCode
                };
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.ExceptionHandler
{
    public class ExceptionManager
    {
        public static ObjectResult ReturnErrorMessage(Exception exception)
        {
            if (exception is CustomException customException)
            {
                return new ObjectResult(customException.GetErrorObject())
                {
                    StatusCode = customException.GetStatusCode()
                };
            }

            var result = new
            {
                ErrorMessage = "Error!",
                DetailedErrorMessage = exception.GetType().Name + ": " + exception.ToString(),
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return new ObjectResult(result);
        }
    }
}

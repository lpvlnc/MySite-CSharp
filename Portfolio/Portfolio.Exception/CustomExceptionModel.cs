using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.ExceptionHandler
{
    public class CustomExceptionModel
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public string DetailedErrorMessage { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }
}

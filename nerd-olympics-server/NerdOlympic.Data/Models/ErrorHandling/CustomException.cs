using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NerdOlympics.Data.Models.ErrorHandling
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }

        public CustomException(int code, string message) 
        {
            ErrorCode= code;
            ErrorMessage= message;
        }
    }
}

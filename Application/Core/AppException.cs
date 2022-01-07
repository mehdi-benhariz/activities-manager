using System.Runtime.Serialization;

namespace Application.Core
{
    public class AppException : Exception
    {
        public int StatusCode { get; set; }
        
        public string  Message { get; set; }

        public string Details { get; set; }
        
        public AppException(int StatusCode, string message, string details = null)
        {
            this.StatusCode = StatusCode;
            this.Message = message;
            this.Details = details;
        }
      
    }
}

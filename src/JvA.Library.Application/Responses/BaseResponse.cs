using System.Collections.Generic;

namespace JvA.Library.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }
        public BaseResponse(bool sucess, string message)
        {
            Message = message;
            Success = sucess;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}

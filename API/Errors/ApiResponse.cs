using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageByStatusCode(statusCode);
        }

        private string GetMessageByStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                404 => "Not Found",
                500 => "Internal server error",
                _ => "An error has occured. Please contact the admin"
            };
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }


    }
}
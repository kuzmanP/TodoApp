
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse()
        {
            Errors = new List<string>();
        }

        // Success response constructor
        public static ApiResponse<T> SuccessResponse(T data, string message = "Request was successful.")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                Errors = null,
                StatusCode = 200
            };
        }

        // Error response constructor
        public static ApiResponse<T> ErrorResponse(List<string> errors, string message = "An error occurred.", int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                Errors = errors,
                StatusCode = statusCode
            };
        }

        // Error response constructor with a single error message
        public static ApiResponse<T> ErrorResponse(string error, string message = "An error occurred.", int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                Errors = new List<string> { error },
                StatusCode = statusCode
            };
        }

    }
}

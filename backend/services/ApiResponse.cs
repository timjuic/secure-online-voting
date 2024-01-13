using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace services
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public ApiError Error { get; set; }

        private ApiResponse(bool success, T data, string message = null, ApiError error = null)
        {
            Success = success;
            Data = data;
            Message = message;
            Error = error;
        }

        public static ApiResponse<T> MakeSuccess(T data, string message = null)
        {
            return new ApiResponse<T>(true, data, message, null);
        }

        public static ApiResponse<T> MakeFailure(ApiError error)
        {
            return new ApiResponse<T>(false, default(T), null, error);
        }

        public ActionResult<ApiResponse<T>> ToActionResult()
        {
            return Success ? (ActionResult<ApiResponse<T>>)new OkObjectResult(this) : new BadRequestObjectResult(this);
        }
    }
}

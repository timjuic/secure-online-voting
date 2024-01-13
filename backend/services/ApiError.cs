using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ApiError
    {
        public int ErrorCode { get; }
        public string ErrorName { get; }
        public string ErrorMessage { get; }

        private ApiError(int errorCode, string errorName, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorName = errorName;
            ErrorMessage = errorMessage;
        }

        public static ApiError ERR_DATABASE_ERROR => new ApiError(1000, "ERR_DATABASE_ERROR", "An error occurred in the database!");
        public static ApiError ERR_CANDIDATE_NOT_FOUND => new ApiError(1001, "ERR_CANDIDATE_NOT_FOUND", "Candidate with specified ID couldn't be found!");
        // Add more static properties as needed
    }
}

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
        public static ApiError ERR_CANDIDATE_DOESNT_EXIST => new ApiError(1001, "ERR_CANDIDATE_DOESNT_EXIST", "Candidate with specified ID doesn't exist!");
        public static ApiError ERR_ELECTION_DOESNT_EXIST => new ApiError(24, "ERR_ELECTION_DOESNT_EXIST", "Election with specified ID doesn't exist!");
        public static ApiError ERR_ELECTION_TITLE_DUPLICATE => new ApiError(25, "ERR_ELECTION_TITLE_DUPLICATE", "Election with that title already exists!");
        public static ApiError ERR_VOTER_DOESNT_EXIST => new ApiError(26, "ERR_VOTER_DOESNT_EXIST", "Voter with specified ID doesn't exist!");
        public static ApiError ERR_VOTER_EMAIL_DUPLICATE => new ApiError(27, "ERR_VOTER_EMAIL_DUPLICATE", "Voter with provided email already exists!");
        public static ApiError ERR_INVALID_FIRST_NAME => new ApiError(28, "ERR_INVALID_FIRST_NAME", "First name must contain only letters and be between 2 and 50 characters.");
        public static ApiError ERR_INVALID_LAST_NAME => new ApiError(29, "ERR_INVALID_LAST_NAME", "Last name must contain only letters and be between 2 and 50 characters.");
        public static ApiError ERR_INVALID_EMAIL => new ApiError(30, "ERR_INVALID_EMAIL", "Invalid email format!");
        public static ApiError ERR_INVALID_PASSWORD => new ApiError(31, "ERR_INVALID_PASSWORD", "Password must be at least 8 characters long and contain both letters and numbers.");
        public static ApiError ERR_INVALID_CREDENTIALS => new ApiError(32, "ERR_INVALID_CREDENTIALS", "Invalid Credentials! Email and password don't match!");

        // Add more static properties as needed
    }
}

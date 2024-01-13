using Database;
using Database.data_access;
using Database.models;
using System.Diagnostics.Metrics;

namespace services.services
{
    public class AuthService
    {
        private readonly VoterRepository _voterRepository;

        public AuthService()
        {
            _voterRepository = RepositoryDependencyProvider.GetVoterRepository();
        }

        //public async Task<ApiResponse<Voter>> LoginUserAsync(String request)
        //{
        //    //try
        //    //{
        //    //    // Validate user credentials (replace with your authentication logic)
        //    //    if (IsValidUser(request.Username, request.Password))
        //    //    {
        //    //        // Retrieve user details (replace with your user retrieval logic)
        //    //        var user = await _userRepository.GetUserByUsernameAsync(request.Username);

        //    //        return ApiResponse<User>.MakeSuccess(user, "User successfully logged in!");
        //    //    }

        //    //    return ApiResponse<User>.MakeFailure(ApiError.ERR_INVALID_CREDENTIALS);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Log the exception if needed
        //    //    return ApiResponse<User>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
        //    //}
        //}

        public async Task<ApiResponse<bool>> RegisterUserAsync(Voter newVoter)
        {
            try
            {
                if (!ValidationHelper.IsValidFirstName(newVoter.FirstName))
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_INVALID_FIRST_NAME);
                }

                if (!ValidationHelper.IsValidLastName(newVoter.LastName))
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_INVALID_LAST_NAME);
                }

                if (!ValidationHelper.IsValidEmail(newVoter.Email))
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_INVALID_EMAIL);
                }

                if (!ValidationHelper.IsValidPassword(newVoter.Password))
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_INVALID_PASSWORD);
                }

                bool voterExists = await _voterRepository.VoterExistsByEmailAsync(newVoter.Email);

                if (voterExists)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_VOTER_EMAIL_DUPLICATE);
                }

                // If validation passes, proceed with creating the voter
                Voter createdUser = await _voterRepository.CreateVoterAsync(newVoter);
                return ApiResponse<bool>.MakeSuccess(true, "User successfully registered!");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }
    }
}

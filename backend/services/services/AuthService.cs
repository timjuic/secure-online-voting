using Database;
using Database.data_access;
using Database.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.services
{
    public class AuthService
    {
        private readonly VoterRepository _voterRepository;;

        public AuthService()
        {
            _voterRepository = RepositoryDependencyProvider.GetVoterRepository();
        }

        public async Task<ApiResponse<Voter>> LoginUserAsync(String request)
        {
            //try
            //{
            //    // Validate user credentials (replace with your authentication logic)
            //    if (IsValidUser(request.Username, request.Password))
            //    {
            //        // Retrieve user details (replace with your user retrieval logic)
            //        var user = await _userRepository.GetUserByUsernameAsync(request.Username);

            //        return ApiResponse<User>.MakeSuccess(user, "User successfully logged in!");
            //    }

            //    return ApiResponse<User>.MakeFailure(ApiError.ERR_INVALID_CREDENTIALS);
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception if needed
            //    return ApiResponse<User>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            //}
        }

        public async Task<ApiResponse<Voter>> RegisterUserAsync(Voter newVoter)
        {
            try
            {

                Voter createdUser = await _voterRepository.CreateVoterAsync(newVoter);

                return ApiResponse<Voter>.MakeSuccess(createdUser, "User successfully registered!");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Voter>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }
    }
}

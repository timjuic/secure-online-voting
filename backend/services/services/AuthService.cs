using Database;
using Database.data_access;
using Database.models;
using Database.requests;
using Database.responses;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace services.services
{
    public class AuthService
    {
        private readonly VoterRepository _voterRepository;

        public AuthService()
        {
            _voterRepository = RepositoryDependencyProvider.GetVoterRepository();
        }

        public async Task<ApiResponse<LoginResponseData>> LoginUserAsync(LoginRequest loginData, IConfiguration configuration)
        {
            
                bool userExists = await _voterRepository.VoterExistsAsync(loginData.Email, loginData.Password);
                if (!userExists)
                {
                    return ApiResponse<LoginResponseData>.MakeFailure(ApiError.ERR_INVALID_CREDENTIALS);
                }

                Voter voter = await _voterRepository.GetVoterByEmailAsync(loginData.Email);

                var jwtTokenResult = JwtHelper.GenerateToken(voter, configuration);

                var responseData = new LoginResponseData
                {
                    JwtToken = jwtTokenResult,
                    User = new UserResponseData
                    {
                        Id = voter.VoterId,
                        FirstName = voter.FirstName,
                        LastName = voter.LastName,
                        Email = voter.Email,
                        IsAdmin = voter.IsAdmin,
                        RegistrationDate = voter.RegistrationDate
                    }
                };

                return ApiResponse<LoginResponseData>.MakeSuccess(responseData, "Login successful!");
        }


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

                string organizationDomain = "foi.hr";
                bool isFoiEmail = ValidationHelper.IsEmailFromOrganization(newVoter.Email, organizationDomain);
                if (!isFoiEmail)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_INVALID_EMAIL_DOMAIN);
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

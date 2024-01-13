using Database;
using Database.data_access;
using Database.models;
using System.Runtime.InteropServices;

namespace services.services
{
    public class VoterService
    {
        private readonly VoterRepository _voterRepository;

        public VoterService()
        {
            _voterRepository = RepositoryDependencyProvider.GetVoterRepository();
        }

        public async Task<ApiResponse<bool>> CreateVoterAsync(Voter voter)
        {
            try
            {
                bool voterExists = await _voterRepository.VoterExistsByEmailAsync(voter.Email);

                if (voterExists)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_VOTER_EMAIL_DUPLICATE);
                }

                // Additional business logic/validation can be added here
                await _voterRepository.CreateVoterAsync(voter);
                return ApiResponse<bool>.MakeSuccess(true, "Voter created successfully");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<List<Voter>>> GetAllVotersAsync()
        {
            try
            {
                var voters = await _voterRepository.GetAllVotersAsync();
                return ApiResponse<List<Voter>>.MakeSuccess(voters);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<List<Voter>>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<Voter>> GetVoterByIdAsync(int voterId)
        {
            try
            {
                var voter = await _voterRepository.GetVoterByIdAsync(voterId);
                if (voter == null)
                {
                    return ApiResponse<Voter>.MakeFailure(ApiError.ERR_VOTER_DOESNT_EXIST);
                }

                return ApiResponse<Voter>.MakeSuccess(voter);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Voter>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> UpdateVoterAsync(Voter voter)
        {
            try
            {
                var existingVoter = await _voterRepository.GetVoterByIdAsync(voter.VoterId);
                if (existingVoter == null)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_VOTER_DOESNT_EXIST);
                }

                // Detect if mail already used when updating it. ANd show proper response. Below doesnt work for some reason
                // Probably because of EF entity tracking (only 1 can be tracked at the same time)
                //var isEmailInUse = await _voterRepository.VoterExistsByEmailAsync(voter.Email);
                //if (isEmailInUse && voter.VoterId != existingVoter.VoterId)
                //{
                //    return ApiResponse<bool>.MakeFailure(ApiError.ERR_VOTER_EMAIL_DUPLICATE);
                //}

                // Additional business logic/validation can be added here
                await _voterRepository.UpdateVoterAsync(voter);
                return ApiResponse<bool>.MakeSuccess(true, "Voter updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> DeleteVoterAsync(int voterId)
        {
            try
            {
                var voter = await _voterRepository.GetVoterByIdAsync(voterId);
                if (voter == null)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_VOTER_DOESNT_EXIST);
                }

                // Additional business logic/validation can be added here
                await _voterRepository.DeleteVoterAsync(voterId);
                return ApiResponse<bool>.MakeSuccess(true, $"Voter with ID: {voterId} deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }
    }

}

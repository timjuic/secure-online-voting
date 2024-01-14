using Database;
using Database.data_access;
using Database.models;
using Database.requests;

namespace services.services
{
    public class ElectionService
    {
        private readonly ElectionRepository _electionRepository;

        public ElectionService()
        {
            _electionRepository = RepositoryDependencyProvider.GetElectionRepository();
        }

        public async Task<ApiResponse<bool>> CreateElectionAsync(CreateElectionRequest electionRequest)
        {
            try
            {
                bool electionExists = await _electionRepository.ElectionExistsByTitleAsync(electionRequest.Title);
                if (electionExists)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_ELECTION_TITLE_DUPLICATE);
                }

                var election = new Election
                {
                    Title = electionRequest.Title,
                    Description = electionRequest.Description,
                    EndDate = electionRequest.EndDate ?? DateTime.UtcNow.AddDays(7),
                };

                await _electionRepository.CreateElectionAsync(election);
                return ApiResponse<bool>.MakeSuccess(true, "Election created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }



        public async Task<ApiResponse<List<Election>>> GetAllElectionsAsync()
        {
            try
            {
                var elections = await _electionRepository.GetAllElectionsAsync();
                return ApiResponse<List<Election>>.MakeSuccess(elections);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<List<Election>>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<Election>> GetElectionByIdAsync(int electionId)
        {
            try
            {
                var election = await _electionRepository.GetElectionByIdAsync(electionId);
                if (election == null)
                {
                    return ApiResponse<Election>.MakeFailure(ApiError.ERR_ELECTION_DOESNT_EXIST);
                }

                return ApiResponse<Election>.MakeSuccess(election);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Election>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> UpdateElectionAsync(Election election)
        {
            try
            {
                var existingElection = await _electionRepository.GetElectionByIdAsync(election.ElectionId);
                if (existingElection == null)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_ELECTION_DOESNT_EXIST);
                }

                await _electionRepository.UpdateElectionAsync(election);
                return ApiResponse<bool>.MakeSuccess(true, "Election updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }


        public async Task<ApiResponse<bool>> DeleteElectionAsync(int electionId)
        {
            try
            {
                Election election = await _electionRepository.GetElectionByIdAsync(electionId);
                if (election == null)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_ELECTION_DOESNT_EXIST);
                }

                await _electionRepository.DeleteElectionAsync(electionId);
                return ApiResponse<bool>.MakeSuccess(true, $"Election with ID {electionId} was successfully deleted");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }
    }
}

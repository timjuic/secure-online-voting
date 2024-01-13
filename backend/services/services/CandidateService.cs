using Database;
using Database.data_access;
using Database.models;

namespace services.services
{
    public class CandidateService
    {
        private readonly CandidateRepository _candidateRepository;
        private readonly ElectionRepository _electionRepository;

        public CandidateService()
        {
            _candidateRepository = RepositoryDependencyProvider.GetCandidateRepository();
            _electionRepository = RepositoryDependencyProvider.GetElectionRepository();
        }

        public async Task<ApiResponse<Candidate>> CreateCandidateAsync(Candidate candidate)
        {
            try
            {
                // Additional business logic/validation can be added here
                Candidate createdCandidate = await _candidateRepository.CreateCandidateAsync(candidate);
                return ApiResponse<Candidate>.MakeSuccess(createdCandidate, "Candidate successfully created!");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Candidate>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<List<Candidate>>> GetAllCandidatesAsync()
        {
            try
            {
                var candidates = await _candidateRepository.GetAllCandidatesAsync();
                return ApiResponse<List<Candidate>>.MakeSuccess(candidates);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<List<Candidate>>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<Candidate>> GetCandidateByIdAsync(int candidateId)
        {
            try
            {
                var candidate = await _candidateRepository.GetCandidateByIdAsync(candidateId);
                return candidate != null ? ApiResponse<Candidate>.MakeSuccess(candidate) : ApiResponse<Candidate>.MakeFailure(ApiError.ERR_CANDIDATE_DOESNT_EXIST);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Candidate>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<List<Candidate>>> GetCandidatesByElectionAsync(int electionId)
        {
            try
            {
                Election election = await _electionRepository.GetElectionByIdAsync(electionId);

                if (election == null)
                {
                    return ApiResponse<List<Candidate>>.MakeFailure(ApiError.ERR_ELECTION_DOESNT_EXIST);
                }

                var candidates = await _candidateRepository.GetCandidatesByElectionAsync(electionId);
                return ApiResponse<List<Candidate>>.MakeSuccess(candidates);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<List<Candidate>>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> UpdateCandidateAsync(Candidate candidate)
        {
            try
            {
                // Additional business logic/validation can be added here
                await _candidateRepository.UpdateCandidateAsync(candidate);
                return ApiResponse<bool>.MakeSuccess(true);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> DeleteCandidateAsync(int candidateId)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetCandidateByIdAsync(candidateId);

                if (candidate == null)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_CANDIDATE_DOESNT_EXIST);
                }

                await _candidateRepository.DeleteCandidateAsync(candidateId);

                return ApiResponse<bool>.MakeSuccess(true, $"Candidate with ID: {candidateId} was successfully deleted!");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }
    }
}

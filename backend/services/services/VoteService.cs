using Database;
using Database.data_access;
using Database.models;

namespace services.services
{
    public class VoteService
    {
        private readonly VoteRepository _votesRepository;
        private readonly ElectionRepository _electionRepository;
        private readonly VoterRepository _voterRepository;
        private readonly CandidateRepository _candidateRepository;

        public VoteService()
        {
            _votesRepository = RepositoryDependencyProvider.GetVoteRepository();
            _electionRepository = RepositoryDependencyProvider.GetElectionRepository();
            _voterRepository = RepositoryDependencyProvider.GetVoterRepository();
            _candidateRepository = RepositoryDependencyProvider.GetCandidateRepository();
        }

        public async Task<ApiResponse<Vote>> CreateVoteAsync(Vote vote)
        {
            try
            {

                bool electionExists = await _electionRepository.ElectionExistsByIdAsync(vote.ElectionId);
                if (!electionExists)
                {
                    return ApiResponse<Vote>.MakeFailure(ApiError.ERR_ELECTION_DOESNT_EXIST);
                }

                bool candidateExists = await _candidateRepository.CandidateExistsByIdAsync(vote.CandidateId);
                if (!candidateExists)
                {
                    return ApiResponse<Vote>.MakeFailure(ApiError.ERR_CANDIDATE_DOESNT_EXIST);
                }

                bool voterExists = await _voterRepository.VoterExistsByIdAsync(vote.VoterId);
                if (!voterExists)
                {
                    return ApiResponse<Vote>.MakeFailure(ApiError.ERR_VOTER_DOESNT_EXIST);
                }


                bool voteExists = await _votesRepository.VoteExistsInElectionAsync(vote.VoterId, vote.ElectionId, vote.CandidateId);

                if (voteExists)
                {
                    return ApiResponse<Vote>.MakeFailure(ApiError.ERR_VOTE_EXISTS_IN_ELECTION);
                }

                Vote createdVote = await _votesRepository.CreateVoteAsync(vote);
                return ApiResponse<Vote>.MakeSuccess(createdVote, "Vote successfully created!");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Vote>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<List<Vote>>> GetAllVotesAsync()
        {
            try
            {
                var votes = await _votesRepository.GetAllVotesAsync();
                return ApiResponse<List<Vote>>.MakeSuccess(votes);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<List<Vote>>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<Vote>> GetVoteByIdAsync(int voteId)
        {
            try
            {
                var vote = await _votesRepository.GetVoteByIdAsync(voteId);
                return vote != null ? ApiResponse<Vote>.MakeSuccess(vote) : ApiResponse<Vote>.MakeFailure(ApiError.ERR_VOTE_DOESNT_EXIST);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<Vote>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> UpdateVoteAsync(Vote vote)
        {
            try
            {
                bool voteExists = await _votesRepository.VoteExistsInElectionAsync(vote.VoterId, vote.ElectionId, vote.CandidateId);

                if (!voteExists)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
                }

                await _votesRepository.UpdateVoteAsync(vote);
                return ApiResponse<bool>.MakeSuccess(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }

        public async Task<ApiResponse<bool>> DeleteVoteAsync(int voteId)
        {
            try
            {
                Vote vote = await _votesRepository.GetVoteByIdAsync(voteId);

                if (vote == null)
                {
                    return ApiResponse<bool>.MakeFailure(ApiError.ERR_VOTE_DOESNT_EXIST);
                }

                await _votesRepository.DeleteVoteAsync(voteId);

                return ApiResponse<bool>.MakeSuccess(true, $"Vote with ID: {voteId} was successfully deleted!");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return ApiResponse<bool>.MakeFailure(ApiError.ERR_DATABASE_ERROR);
            }
        }
    }
}

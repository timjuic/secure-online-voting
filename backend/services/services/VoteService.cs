using Database;
using Database.data_access;
using Database.models;

namespace services.services
{
    public class VoteService
    {
        private readonly VoteRepository _votesRepository;

        public VoteService()
        {
            _votesRepository = RepositoryDependencyProvider.GetVoteRepository();
        }

        public async Task CreateVoteAsync(Vote vote)
        {
            // Additional business logic/validation can be added here
            await _votesRepository.CreateVoteAsync(vote);
        }

        public async Task<List<Vote>> GetAllVotesAsync()
        {
            return await _votesRepository.GetAllVotesAsync();
        }

        public async Task<Vote> GetVoteByIdAsync(int voteId)
        {
            return await _votesRepository.GetVoteByIdAsync(voteId);
        }

        public async Task UpdateVoteAsync(Vote vote)
        {
            // Additional business logic/validation can be added here
            await _votesRepository.UpdateVoteAsync(vote);
        }

        public async Task DeleteVoteAsync(int voteId)
        {
            // Additional business logic/validation can be added here
            await _votesRepository.DeleteVoteAsync(voteId);
        }
    }
}

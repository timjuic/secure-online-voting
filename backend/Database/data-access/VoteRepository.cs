using Database.models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Database.data_access
{
    public class VoteRepository
    {
        private readonly DatabaseContext _dbContext;

        public VoteRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vote> CreateVoteAsync(Vote vote)
        {
            _dbContext.Entry(vote).State = EntityState.Detached;
            _dbContext.Votes.Add(vote);
            await _dbContext.SaveChangesAsync();

            return vote;
        }

        public async Task<List<Vote>> GetAllVotesAsync()
        {
            return await _dbContext.Votes.ToListAsync();
        }

        public async Task<Vote> GetVoteByIdAsync(int voteId)
        {
            return await _dbContext.Votes.FindAsync(voteId);
        }

        public async Task UpdateVoteAsync(Vote vote)
        {
            _dbContext.Entry(vote).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVoteAsync(int voteId)
        {
            var vote = await _dbContext.Votes.FindAsync(voteId);
            if (vote != null)
            {
                _dbContext.Votes.Remove(vote);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> VoteExistsInElectionAsync(int voterID, int electionID, int candidateID)
        {
            return await _dbContext.Votes.AnyAsync(v => v.VoterId == voterID && v.ElectionId == electionID && v.CandidateId == candidateID);
        }

       
    }
}

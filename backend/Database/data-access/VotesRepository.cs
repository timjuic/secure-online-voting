using Database.models;
using Microsoft.EntityFrameworkCore;

namespace Database.data_access
{
    public class VotesRepository
    {
        private readonly DatabaseContext _dbContext;

        public VotesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateVoteAsync(Vote vote)
        {
            _dbContext.Votes.Add(vote);
            await _dbContext.SaveChangesAsync();
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
    }
}

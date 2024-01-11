using Database.models;
using Microsoft.EntityFrameworkCore;

namespace Database.data_access
{
    public class VotersRepository
    {
        private readonly DatabaseContext _dbContext;

        public VotersRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create a new voter
        public async Task CreateVoterAsync(Voter voter)
        {
            _dbContext.Voters.Add(voter);
            await _dbContext.SaveChangesAsync();
        }

        // Retrieve all voters
        public async Task<List<Voter>> GetAllVotersAsync()
        {
            return await _dbContext.Voters.ToListAsync();
        }

        // Retrieve a voter by ID
        public async Task<Voter> GetVoterByIdAsync(int voterId)
        {
            return await _dbContext.Voters.FindAsync(voterId);
        }

        // Retrieve a voter by email
        public async Task<Voter> GetVoterByEmailAsync(string email)
        {
            return await _dbContext.Voters.FirstOrDefaultAsync(v => v.Email == email);
        }

        // Update a voter
        public async Task UpdateVoterAsync(Voter voter)
        {
            _dbContext.Entry(voter).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Delete a voter by ID
        public async Task DeleteVoterAsync(int voterId)
        {
            var voter = await _dbContext.Voters.FindAsync(voterId);
            if (voter != null)
            {
                _dbContext.Voters.Remove(voter);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

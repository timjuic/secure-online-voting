using Database.models;
using Microsoft.EntityFrameworkCore;

namespace Database.data_access
{
    public class VoterRepository
    {
        private readonly DatabaseContext _dbContext;

        public VoterRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Voter> CreateVoterAsync(Voter voter)
        {
            _dbContext.Entry(voter).State = EntityState.Detached;
            _dbContext.Voters.Add(voter);
            await _dbContext.SaveChangesAsync();

            return voter;
        }

        public async Task<List<Voter>> GetAllVotersAsync()
        {
            return await _dbContext.Voters.ToListAsync();
        }

        public async Task<Voter> GetVoterByIdAsync(int voterId)
        {
            return await _dbContext.Voters.FindAsync(voterId);
        }

        public async Task<Voter> GetVoterByEmailAsync(string email)
        {
            return await _dbContext.Voters.FirstOrDefaultAsync(v => v.Email == email);
        }

        public async Task UpdateVoterAsync(Voter voter)
        {
            var existingVoter = await _dbContext.Voters.FindAsync(voter.VoterId);

            if (existingVoter != null)
            {
                _dbContext.Entry(existingVoter).State = EntityState.Detached;
                _dbContext.Entry(voter).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteVoterAsync(int voterId)
        {
            var voter = await _dbContext.Voters.FindAsync(voterId);
            if (voter != null)
            {
                _dbContext.Voters.Remove(voter);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> VoterExistsByEmailAsync(string email)
        {
            return await _dbContext.Voters.AnyAsync(v => v.Email == email);
        }

        public async Task<bool> VoterExistsAsync(string email, string password)
        {
            return await _dbContext.Voters
                .AnyAsync(u => u.Email == email && password == u.Password);
        }

        public async Task<bool> VoterExistsByIdAsync(int voterId)
        {
            return await _dbContext.Voters.AnyAsync(v => v.VoterId == voterId);
        }

        public async Task<string> GetPasswordHashByEmailAsync(string email)
        {
            var user = await _dbContext.Voters.SingleOrDefaultAsync(v => v.Email == email);
            return user?.Password;
        }

    }
}

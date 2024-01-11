using Database.models;
using Microsoft.EntityFrameworkCore;

namespace Database.data_access
{
    public class ElectionRepository
    {
        private readonly DatabaseContext _dbContext;

        public ElectionRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateElectionAsync(Election election)
        {
            _dbContext.Elections.Add(election);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Election>> GetAllElectionsAsync()
        {
            return await _dbContext.Elections.ToListAsync();
        }

        public async Task<Election> GetElectionByIdAsync(int electionId)
        {
            return await _dbContext.Elections.FindAsync(electionId);
        }

        public async Task UpdateElectionAsync(Election election)
        {
            _dbContext.Entry(election).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteElectionAsync(int electionId)
        {
            var election = await _dbContext.Elections.FindAsync(electionId);
            if (election != null)
            {
                _dbContext.Elections.Remove(election);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

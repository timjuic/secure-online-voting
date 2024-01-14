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
            if (election.StartDate == default)
            {
                election.StartDate = DateTime.UtcNow;
            }

            if (election.IsActive == default)
            {
                election.IsActive = 1;
            }

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
            // Detach existing entity, if it's being tracked
            var existingEntry = _dbContext.ChangeTracker.Entries<Election>().FirstOrDefault(x => x.Entity.ElectionId == election.ElectionId);
            if (existingEntry != null)
            {
                existingEntry.State = EntityState.Detached;
            }

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

        public async Task<bool> ElectionExistsByTitleAsync(string electionTitle)
        {
            return await _dbContext.Elections.AnyAsync(e => e.Title == electionTitle);
        }

        public async Task<bool> ElectionExistsByIdAsync(int electionId)
        {
            return await _dbContext.Elections.AnyAsync(e => e.ElectionId == electionId);
        }
    }
}

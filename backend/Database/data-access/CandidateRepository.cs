using Database.models;
using Microsoft.EntityFrameworkCore;

namespace Database.data_access
{
    public class CandidateRepository
    {
        private readonly DatabaseContext _dbContext;

        public CandidateRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCandidateAsync(Candidate candidate)
        {
            _dbContext.Candidates.Add(candidate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Candidate>> GetAllCandidatesAsync()
        {
            return await _dbContext.Candidates.ToListAsync();
        }

        public async Task<List<Candidate>> GetCandidatesByElectionAsync(int electionId)
        {
            return await _dbContext.Candidates
                .Where(candidate => _dbContext.CandidateElections
                    .Any(ce => ce.CandidateId == candidate.CandidateId && ce.ElectionId == electionId))
                .ToListAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int candidateId)
        {
            return await _dbContext.Candidates.FindAsync(candidateId);
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            _dbContext.Entry(candidate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCandidateAsync(int candidateId)
        {
            var candidate = await _dbContext.Candidates.FindAsync(candidateId);
            if (candidate != null)
            {
                _dbContext.Candidates.Remove(candidate);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

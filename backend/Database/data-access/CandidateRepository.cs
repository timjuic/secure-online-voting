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

        public async Task<Candidate> CreateCandidateAsync(Candidate candidate)
        {
            _dbContext.Candidates.Add(candidate);
            await _dbContext.SaveChangesAsync();
            return candidate;
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
            var existingCandidate = await _dbContext.Candidates
                .FirstOrDefaultAsync(c => c.CandidateId == candidate.CandidateId);

            if (existingCandidate != null)
            {
                _dbContext.Candidates.Attach(existingCandidate);
                existingCandidate.Name = candidate.Name;  // Update other properties similarly
                existingCandidate.PartyAffiliation = candidate.PartyAffiliation;
                existingCandidate.Position = candidate.Position;

                await _dbContext.SaveChangesAsync();
            }
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

        public async Task<bool> CandidateExistsByNameAsync(string candidateName)
        {
            return await _dbContext.Candidates.AnyAsync(c => c.Name == candidateName);
        }

        public async Task<bool> CandidateExistsWithNameAsync(string candidateName, int candidateIdToExclude)
        {
            return await _dbContext.Candidates
                .AnyAsync(c => c.Name == candidateName && c.CandidateId != candidateIdToExclude);
        }

        public async Task<bool> CandidateExistsByIdAsync(int candidateId)
        {
            return await _dbContext.Candidates.AnyAsync(c => c.CandidateId == candidateId);
        }
    }
}

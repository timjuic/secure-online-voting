using Database;
using Database.data_access;
using Database.models;

namespace services.services
{
    public class CandidateService
    {
        private readonly CandidateRepository _candidateRepository;

        public CandidateService()
        {
            _candidateRepository = RepositoryDependencyProvider.GetCandidateRepository();
        }

        public async Task CreateCandidateAsync(Candidate candidate)
        {
            // Additional business logic/validation can be added here
            await _candidateRepository.CreateCandidateAsync(candidate);
        }

        public async Task<List<Candidate>> GetAllCandidatesAsync()
        {
            return await _candidateRepository.GetAllCandidatesAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int candidateId)
        {
            return await _candidateRepository.GetCandidateByIdAsync(candidateId);
        }

        public async Task<List<Candidate>> GetCandidatesByElectionAsync(int electionId)
        {
            return await _candidateRepository.GetCandidatesByElectionAsync(electionId);
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            // Additional business logic/validation can be added here
            await _candidateRepository.UpdateCandidateAsync(candidate);
        }

        public async Task DeleteCandidateAsync(int candidateId)
        {
            // Additional business logic/validation can be added here
            await _candidateRepository.DeleteCandidateAsync(candidateId);
        }
    }
}

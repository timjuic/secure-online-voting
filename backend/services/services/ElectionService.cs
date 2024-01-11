using Database.data_access;
using Database.models;

namespace services.services
{
    public class ElectionService
    {
        private readonly ElectionRepository _electionRepository;

        public ElectionService(ElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }

        public async Task CreateElectionAsync(Election election)
        {
            // Additional business logic/validation can be added here
            await _electionRepository.CreateElectionAsync(election);
        }

        public async Task<List<Election>> GetAllElectionsAsync()
        {
            return await _electionRepository.GetAllElectionsAsync();
        }

        public async Task<Election> GetElectionByIdAsync(int electionId)
        {
            return await _electionRepository.GetElectionByIdAsync(electionId);
        }

        public async Task UpdateElectionAsync(Election election)
        {
            // Additional business logic/validation can be added here
            await _electionRepository.UpdateElectionAsync(election);
        }

        public async Task DeleteElectionAsync(int electionId)
        {
            // Additional business logic/validation can be added here
            await _electionRepository.DeleteElectionAsync(electionId);
        }
    }
}

using Database.data_access;
using Database.models;

namespace services.services
{
    public class VoterService
    {
        private readonly VoterRepository _voterRepository;

        public VoterService(VoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public VoterService()
        {
                
        }

        public async Task CreateVoterAsync(Voter voter)
        {
            // Additional business logic/validation can be added here
            await _voterRepository.CreateVoterAsync(voter);
        }

        public async Task<List<Voter>> GetAllVotersAsync()
        {
            return await _voterRepository.GetAllVotersAsync();
        }

        public async Task<Voter> GetVoterByIdAsync(int voterId)
        {
            return await _voterRepository.GetVoterByIdAsync(voterId);
        }

        public async Task UpdateVoterAsync(Voter voter)
        {
            // Additional business logic/validation can be added here
            await _voterRepository.UpdateVoterAsync(voter);
        }

        public async Task DeleteVoterAsync(int voterId)
        {
            // Additional business logic/validation can be added here
            await _voterRepository.DeleteVoterAsync(voterId);
        }
    }

}

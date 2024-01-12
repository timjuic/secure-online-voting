using Database.data_access;

namespace Database
{
    public static class RepositoryDependencyProvider
    {
        private static CandidateRepository? _candidateRepository;
        private static ElectionRepository? _electionRepository;
        private static VoterRepository? _voterRepository;
        private static VoteRepository? _voteRepository;
        private static readonly DatabaseContext _dbContext = new DatabaseContext();

        public static CandidateRepository GetCandidateRepository()
        {
            if (_candidateRepository == null)
            {
                _candidateRepository = new CandidateRepository(_dbContext);
            }

            return _candidateRepository;
        }

        public static ElectionRepository GetElectionRepository()
        {
            if (_electionRepository == null)
            {
                _electionRepository = new ElectionRepository(_dbContext);
            }

            return _electionRepository;
        }

        public static VoterRepository GetVoterRepository()
        {
            if (_voterRepository == null)
            {
                _voterRepository = new VoterRepository(_dbContext);
            }

            return _voterRepository;
        }

        public static VoteRepository GetVoteRepository()
        {
            if (_voteRepository == null)
            {
                _voteRepository = new VoteRepository(_dbContext);
            }

            return _voteRepository;
        }
    }
}

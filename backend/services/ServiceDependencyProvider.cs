using Database.data_access;
using services.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ServiceDependencyProvider
    {
        private CandidateService? _candidateService;
        private ElectionService? _electionService;
        private VoterService? _voterService;
        private VoteService? _voteService;

        public CandidateService GetCandidateService()
        {
            if (_candidateService == null)
            {
                _candidateService = new CandidateService();
            }

            return _candidateService;
        }

        public ElectionService GetElectionService()
        {
            if (_electionService == null)
            {
                _electionService = new ElectionService();
            }

            return _electionService;
        }

        public VoterService GetVoterService()
        {
            if (_voterService == null)
            {
                _voterService = new VoterService();
            }

            return _voterService;
        }

        public VoteService GetVoteService()
        {
            if (_voteService == null)
            {
                _voteService = new VoteService();
            }

            return _voteService;
        }
    }

}

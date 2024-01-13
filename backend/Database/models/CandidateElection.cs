using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class CandidateElection
    {
        [Key, Column("candidate_id")]
        public int CandidateId { get; set; }

        [Key, Column("election_id")]
        public int ElectionId { get; set; }

        // Navigation properties
        public Candidate Candidate { get; set; }
        public Election Election { get; set; }
    }
}

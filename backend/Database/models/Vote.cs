using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Database.models
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        public int VoterId { get; set; }

        [Required]
        public int ElectionId { get; set; }

        [Required]
        public int CandidateId { get; set; }

        [Required]
        public DateTime VoteTimestamp { get; set; }

        // Navigation properties
        public Voter Voter { get; set; }
        public Election Election { get; set; }
        public Candidate Candidate { get; set; }
    }
}

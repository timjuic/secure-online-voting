using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Database.models
{
    public class Vote
    {
        [Key]
        [Column("vote_id")]
        public int VoteId { get; set; }

        [Column("voter_id")]
        public int VoterId { get; set; }

        [Column("election_id")]
        public int ElectionId { get; set; }

        [Column("candidate_id")]
        public int CandidateId { get; set; }

        [Column("vote_timestamp")]
        public DateTime VoteTimestamp { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Voter? Voter { get; set; }
        [JsonIgnore]
        public Election? Election { get; set; }
        [JsonIgnore]
        public Candidate? Candidate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class Candidate
    {
        [Key]
        [Column("candidate_id")]
        public int CandidateId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("party_affiliation")]
        public string PartyAffiliation { get; set; }

        [Column("position")]
        public string Position { get; set; }

        // Navigation properties
        public List<CandidateElection> CandidateElections { get; set; }
        public List<Vote> Votes { get; set; }
    }
}

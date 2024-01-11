using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PartyAffiliation { get; set; }

        [Required]
        public string Position { get; set; }

        // Navigation properties
        public List<Vote> Votes { get; set; }
        public List<CandidateElection> CandidateElections { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class CandidateElection
    {
        [Key]
        public int CandidateId { get; set; }

        [Key]
        public int ElectionId { get; set; }

        // Navigation properties
        public Candidate Candidate { get; set; }
        public Election Election { get; set; }
    }
}

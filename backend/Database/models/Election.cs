using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class Election
    {
        [Key]
        public int ElectionId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        // Navigation properties
        public List<Vote> Votes { get; set; }
        public List<CandidateElection> CandidateElections { get; set; }
    }
}

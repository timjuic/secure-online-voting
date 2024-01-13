using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class Election
    {
        [Key]
        [Column("election_id")]
        public int ElectionId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("is_active")]
        public int IsActive { get; set; }

        // Navigation properties
        public List<CandidateElection>? CandidateElections { get; set; }
        public List<Vote>? Votes { get; set; }
    }
}

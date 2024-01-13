using Database.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class Voter
    {
        [Key]
        [Column("voter_id")] // This is important to match the SQLite column name
        public int VoterId { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [Column("is_admin")]
        public int IsAdmin { get; set; } // Adjust the type based on your needs

        // Navigation property
        public List<Vote> Votes { get; set; }
    }
}
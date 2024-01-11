using Database.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.models
{
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int IsAdmin { get; set; } // Adjust the type based on your needs

        // Navigation property
        public List<Vote> Votes { get; set; }
    }
}
using Database.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.data_access
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<CandidateElection> CandidateElections { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            // Move up one level
            string parentDirectory = Directory.GetParent(currentDirectory)?.FullName;

            if (parentDirectory != null)
            {
                string databaseFilePath = Path.Combine(parentDirectory, "Database", "database.sqlite");
                Console.WriteLine(databaseFilePath);
                optionsBuilder.UseSqlite($"Data Source={databaseFilePath}");
            }
            else
            {
                // Handle the case where we couldn't get the parent directory
                // Log an error, throw an exception, or handle it as appropriate for your scenario.
                throw new InvalidOperationException("Could not determine parent directory.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite primary key for CandidateElections
            modelBuilder.Entity<CandidateElection>()
                .HasKey(ce => new { ce.CandidateId, ce.ElectionId });

            // Configure relationships

            // Voter to Vote (One-to-Many)
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Voter)
                .WithMany(voter => voter.Votes)
                .HasForeignKey(v => v.VoterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Election to Vote (One-to-Many)
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Election)
                .WithMany(e => e.Votes)
                .HasForeignKey(v => v.ElectionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Candidate to Vote (One-to-Many)
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Candidate)
                .WithMany(candidate => candidate.Votes)
                .HasForeignKey(v => v.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);

            // CandidateElection to Candidate (Many-to-One)
            modelBuilder.Entity<CandidateElection>()
                .HasOne(ce => ce.Candidate)
                .WithMany(candidate => candidate.CandidateElections)
                .HasForeignKey(ce => ce.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);

            // CandidateElection to Election (Many-to-One)
            modelBuilder.Entity<CandidateElection>()
                .HasOne(ce => ce.Election)
                .WithMany(election => election.CandidateElections)
                .HasForeignKey(ce => ce.ElectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

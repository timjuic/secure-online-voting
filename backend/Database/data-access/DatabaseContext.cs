using Database.models;
using Microsoft.EntityFrameworkCore;


namespace Database
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
            // Configure your database connection here
            optionsBuilder.UseSqlite("Data Source=database.sqlite");
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

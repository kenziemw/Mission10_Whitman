//kenzie whitman section 3
using Microsoft.EntityFrameworkCore;
using backend.Models;  

namespace backend.Data  
{
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        public DbSet<Bowlers> Bowlers { get; set; }  // Ensure this matches the database table
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowlers>()
                .HasKey(b => b.BowlerID);  // Matches the primary key in SQLite

            modelBuilder.Entity<Bowlers>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamID);

            base.OnModelCreating(modelBuilder);
        }
    }
}

// Weston Watson, Section 3

using Microsoft.EntityFrameworkCore;
using BowlingAPI.Models;

namespace BowlingAPI.Data
{
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Teams"); // Ensure correct table mapping
            modelBuilder.Entity<Bowler>().ToTable("Bowlers"); // 👈 Ensure correct table mapping
        }
    }
}

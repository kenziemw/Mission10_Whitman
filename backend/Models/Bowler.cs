// Weston Watson, Section 3

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingAPI.Models
{
    [Table("Bowlers")] // 👈 This ensures EF maps to the correct table name
    public class Bowler
    {
        [Key]
        public int BowlerID { get; set; }
        public string? BowlerFirstName { get; set; }
        public string? BowlerMiddleInit { get; set; }
        public string? BowlerLastName { get; set; }
        public string? BowlerAddress { get; set; }
        public string? BowlerCity { get; set; }
        public string? BowlerState { get; set; }
        public string? BowlerZip { get; set; }
        public string? BowlerPhoneNumber { get; set; }

        [ForeignKey("Team")]
        public int? TeamID { get; set; } // 👈 Ensure this is nullable to match the DB schema
        public Team? Team { get; set; }
    }
}

// Weston Watson, Section 3

using System.ComponentModel.DataAnnotations;

namespace BowlingAPI.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
    }
}

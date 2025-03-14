namespace backend.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public List<Bowlers>? Bowlers { get; set; }
    }
}

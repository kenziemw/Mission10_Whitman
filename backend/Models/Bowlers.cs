namespace backend.Models
{
    public class Bowlers
    {
        public int BowlerID { get; set; }  // Matches database schema
        public string? BowlerFirstName { get; set; }  
        public string? BowlerMiddleInit { get; set; }  
        public string? BowlerLastName { get; set; }  
        public string? BowlerAddress { get; set; }  
        public string? BowlerCity { get; set; }  
        public string? BowlerState { get; set; }  
        public string? BowlerZip { get; set; }  
        public string? BowlerPhoneNumber { get; set; }  
        public int? TeamID { get; set; }  // Foreign key
        public Team? Team { get; set; }   // Navigation property
    }
}

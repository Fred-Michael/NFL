namespace NFPL.Models
{
    public class Team
    {
        public string TeamID { get; set; }
        public string Name { get; set; }
        public Division Division { get; set; }
        public Conference Conference { get; set; }
        public string TeamLogo { get; set; }
    }
}
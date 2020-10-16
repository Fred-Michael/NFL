using NFPL.Models;

namespace NFPL.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public string ActiveConference { get; set; } = "all";
        public string ActiveDivision { get; set; } = "all";
    }
}
using NFPL.Models;
using System.Collections.Generic;

namespace NFPL.ViewModels
{
    public class TeamListViewModel : TeamViewModel
    {
        public List<Team> Teams { get; set; }
        private List<Conference> conferences { get; set; }
        private List<Division> divisions { get; set; }
        public List<Conference> Conferences
        {
            get => conferences;
            set
            {
                conferences = value;
                conferences.Insert(0, new Conference { ConferenceID = "all", Name = "All" });
            }
        }
        public List<Division> Divisions
        {
            get => divisions;
            set
            {
                divisions = value;
                divisions.Insert(0, new Division { DivisionID = "all", Name = "All" });
            }
        }
        public string CheckActiveConference(string check) => check.ToLower() == ActiveConference.ToLower() ? "active" : "";
        public string CheckActiveDivision(string check) => check.ToLower() == ActiveDivision.ToLower() ? "active" : "";
    }
}
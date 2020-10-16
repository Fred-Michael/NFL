using Microsoft.AspNetCore.Http;
using NFPL.Models;
using System.Collections.Generic;

namespace NFPL.Sessions
{
    public class NFLSession
    {
        private const string TeamsKey = "myteams";
        private const string CountKey = "teamcount";
        private const string ConferenceKey = "conf";
        private const string DivisionKey = "div";

        private ISession _session { get; set; }

        public NFLSession(ISession session)
        {
            _session = session;
        }

        public void SetTeams(List<Team> teams)
        {
            _session.SetObject(TeamsKey, teams);
            _session.SetInt32(CountKey, teams.Count);
        }

        public List<Team> GetTeams() => _session.GetObject<List<Team>>(TeamsKey) ?? new List<Team>();

        public int? GetTeamCount()
        {
            return _session.GetInt32(CountKey);
        }

        public void SetActiveConference(string conference)
        {
            _session.SetString(ConferenceKey, conference);
        }

        public string GetActiveConference()
        {
            return _session.GetString(ConferenceKey);
        }

        public void SetActiveDivision(string division)
        {
            _session.SetString(DivisionKey, division);
        }

        public string GetActiveDivision() 
        {
            return _session.GetString(DivisionKey);
        }

        public void RemoveTeam()
        {
            _session.Remove(TeamsKey);
            _session.Remove(CountKey);
        }
    }
}
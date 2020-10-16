using Microsoft.AspNetCore.Http;
using NFPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFPL.Sessions
{
    public class NFLCookies
    {
        private const string TeamsKey = "myteams";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public NFLCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }

        public NFLCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyTeamsIds(List<Team> myTeams)
        {
            var ids = myTeams.Select(team => team.TeamID).ToList();
            string idString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(10) };
            RemoveTeamId();
            responseCookies.Append(TeamsKey, idString, options);
        }

        public string[] GetTeamsIds()
        {
            var cookies = requestCookies[TeamsKey];
            if (string.IsNullOrEmpty(cookies))
            {
                return new string[] { };
            }
            return cookies.Split(Delimiter);
        }

        public void RemoveTeamId()
        {
            responseCookies.Delete(TeamsKey);
        }
    }
}
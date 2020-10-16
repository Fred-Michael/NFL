using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NFPL.Data;
using NFPL.Models;
using NFPL.Sessions;
using NFPL.ViewModels;

namespace NFPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DbContextApp _ctx;

        public HomeController(ILogger<HomeController> logger, DbContextApp ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index(string activeConf = "all", string activeDiv = "all")
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetActiveConference(activeConf);
            session.SetActiveDivision(activeDiv);

            int? count = session.GetTeamCount();

            if (count == null)
            {
                var cookies = new NFLCookies(Request.Cookies);
                string[] ids = cookies.GetTeamsIds();

                List<Team> myTeams = new List<Team>();
                if (ids.Length > 0)
                {
                    myTeams = _ctx.Teams.Include(c => c.Conference)
                                        .Include(d => d.Division)
                                        .Where(t => ids.Contains(t.TeamID))
                                        .ToList();
                }
                //this preserves the state of the cookies even after the browser has been closed...as long as it doesn't exceed 10days
                session.SetTeams(myTeams);
            }

            var data = new TeamListViewModel
            {
                ActiveConference = activeConf,
                ActiveDivision = activeDiv,
                Conferences = _ctx.Conferences.ToList(),
                Divisions = _ctx.Divisions.ToList()
            };

            IEnumerable<Team> query = _ctx.Teams;

            if (activeConf != "all") query = query.Where(t => t.Conference.ConferenceID.ToLower() == activeConf.ToLower());

            if (activeDiv != "all") query = query.Where(d => d.Division.DivisionID.ToLower() == activeDiv.ToLower());

            data.Teams = query.ToList();

            return View(data);
        }

        public IActionResult Details(string Id)
        {
            var session = new NFLSession(HttpContext.Session);

            var model = new TeamViewModel
            {
                Team = _ctx.Teams
                           .Include(conf => conf.Conference)
                           .Include(div => div.Division)
                           .FirstOrDefault(team => team.TeamID == Id),

                ActiveConference = session.GetActiveConference(),
                ActiveDivision = session.GetActiveDivision()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(TeamViewModel model)
        {
            model.Team = _ctx.Teams.Include(c => c.Conference)
                                   .Include(d => d.Division)
                                   .Where(t => t.TeamID == model.Team.TeamID)
                                   .FirstOrDefault();

            var session = new NFLSession(HttpContext.Session);
            var teams = session.GetTeams();
            teams.Add(model.Team);
            session.SetTeams(teams);

            var cookies = new NFLCookies(Response.Cookies);
            cookies.SetMyTeamsIds(teams);

            TempData["message"] = $"{model.Team.Name} was added to your favorites";

            return RedirectToAction("Index", new { activeConf = session.GetActiveConference(), activeDiv = session.GetActiveDivision() });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using NFPL.Sessions;
using NFPL.ViewModels;

namespace NFPL.Controllers
{
    public class FavoritesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveConference = session.GetActiveConference(),
                ActiveDivision = session.GetActiveDivision(),
                Teams = session.GetTeams()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new NFLSession(HttpContext.Session);
            var cookies = new NFLCookies(Response.Cookies);

            //remove team from the session and delete that session
            session.RemoveTeam();
            cookies.RemoveTeamId();

            //message to be passed to the redirect route
            TempData["message"] = $"Favorite teams were removed";

            return RedirectToAction("Index", "Home", new { activeConf = session.GetActiveConference(), activeDiv = session.GetActiveDivision() });
        }
    }
}
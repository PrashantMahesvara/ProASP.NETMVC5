using System.Collections.Generic;
using System.Web.Mvc;
using SimpleApp.Project1.Models;

namespace SimpleApp.Project1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View(HttpContext.Application["events"]);
            return View(GetTimeStamps());
        }

        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if(oldColor != null)
            {
                Vote.ChangeVote(color, (Color)oldColor);
            }
            else
            {
                Vote.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            return View(GetTimeStamps());
            //return View(HttpContext.Application["events"]);
        }

        private List<string> GetTimeStamps()
        {
            return new List<string>
            {
                string.Format("App timestamp: {0}",
                HttpContext.Application["app_timestamp"]),
                string.Format("Request timestamp: {0}", Session["request_timestamp"])
            };
        }
    }
}

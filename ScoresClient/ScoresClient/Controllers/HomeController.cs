using ScoresClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ScoresClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ScoresService serv = new ScoresService();
            var players = await serv.GetPlayers();
            return View(players);
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";

            ScoresService serv = new ScoresService();
            var player = await serv.GetPlayerByID(3);
            return View(player);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
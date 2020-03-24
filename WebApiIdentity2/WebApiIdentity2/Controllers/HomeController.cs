using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiIdentity2.Data;
using WebApiIdentity2.Models;

namespace WebApiIdentity2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ApplicationDbContext context)
        {
            db = context;
            //_logger = logger;
        }

        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

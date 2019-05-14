using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiClientCore.Models;
using WebApiClientCore.Services;

namespace WebApiClientCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public ViewResult Users()
        {
            UsersService serv = new UsersService();
            var users = serv.GetUsers().Result;
            return View(users);
        }

        public ViewResult ShowUser(int id)
        {
            UsersService serv = new UsersService();
            var user = serv.GetUsersByID(id).Result;
            return View(user);
        }

        [HttpGet]
        public ViewResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([Bind("Name","Age")] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsersService serv = new UsersService();
            var res = await serv.AddUser(user);
            return RedirectToAction("Users","Home");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

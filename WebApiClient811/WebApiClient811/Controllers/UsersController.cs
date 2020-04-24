using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiClient811.Models;
using WebApiClient811.Services;

namespace WebApiClient811.Controllers
{
    public class UsersController : Controller
    {
        UsersService serv = new UsersService();

        public async Task<IActionResult> Index()
        {
            return View(await serv.GetUsers());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await serv.GetUsersByID(id));
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Age")] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);                
            }

            var res = await serv.AddUser(user);
            if (res == System.Net.HttpStatusCode.Created)
                return RedirectToAction("Index");
            else
                return View(user);
        }


    }
}
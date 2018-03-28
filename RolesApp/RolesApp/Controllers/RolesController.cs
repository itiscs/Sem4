using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RolesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RolesApp.Controllers
{
    [Authorize(Roles ="Админ")]
    public class RolesController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        RoleManager<IdentityRole> roleManager;

        public RolesController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        }


        // GET: Roles
        public ActionResult Index()
        {
            
            return View(roleManager.Roles);
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
                                (new UserStore<ApplicationUser>(db));

            RoleUsersViewModel ruVM = new RoleUsersViewModel()
                        { Id = role.Id, Name = role.Name };
            ruVM.Users = new List<ApplicationUser>();
            
            foreach(var user in role.Users)
            {
                ruVM.Users.Add(userManager.FindById(user.UserId));
            }
            return View(ruVM);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create([Bind(Include="Name")] IdentityRole role)
        {
            try
            {
                roleManager.Create(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }
            
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var role = roleManager.FindById(id);
                roleManager.Delete(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

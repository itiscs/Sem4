using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityApp.Controllers
{

    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Email,PhoneNumber,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                var result = await userManager.CreateAsync(applicationUser,"123456");
                if(result.Succeeded)
                    return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            ApplicationUser applicationUser = userManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            UserRolesViewModel userRoles = new UserRolesViewModel() { User = applicationUser, Id = applicationUser.Id };
            userRoles.Roles = new Dictionary<IdentityRole,bool>();
            foreach (var role in roleManager.Roles)
            {
                var b = applicationUser.Roles.FirstOrDefault(u=>u.RoleId== role.Id) != null;
                userRoles.Roles.Add(role, b);
            }
            return View(userRoles);
        }

        // POST: ApplicationUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]  //[Bind(Include = "Email,PhoneNumber,UserName, Roles")] 
        public ActionResult Edit( UserRolesViewModel userRoles)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(userRoles.User).State = EntityState.Modified;
                //db.SaveChanges();

                foreach(var role in userRoles.Roles)
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                    var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                    if (role.Value)
                    {
                        if (roleManager.FindByName(role.Key.Name).Users.All(u => u.UserId != userRoles.Id))
                            userManager.AddToRole(userRoles.Id,role.Key.Name);
                    }
                    else
                    {
                        if (roleManager.FindByName(role.Key.Name).Users.Any(u => u.UserId == userRoles.Id))
                            userManager.RemoveFromRole(userRoles.Id, role.Key.Name);
                    }

                }

                return RedirectToAction("Index");
            }
            return View(userRoles);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

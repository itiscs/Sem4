using IdentityApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IdentityApp.Controllers
{
    
    public class RolesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> rolesManager;

        public RolesController()
        {
            RoleManager<IdentityRole> rolesManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

        }

        // UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        // GET: Roles
        public ActionResult Index()
        {

            return View(db.Roles.ToList());
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole ir = new IdentityRole(role.Name);
                rolesManager.Create(ir);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleManager<IdentityRole> rolesManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role = rolesManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel rvm = new RoleViewModel() { Id = role.Id, Name = role.Name };
            rvm.AppUsers = new List<ApplicationUser>();
            foreach (var user in role.Users)
            {
                ((List<ApplicationUser>)rvm.AppUsers).Add(db.Users.Find(user.UserId));
            }
            return View(rvm);
        }

        // POST: ApplicationUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Users")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(role);
            
        }




    }
}
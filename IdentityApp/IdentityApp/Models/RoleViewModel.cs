using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityApp.Models
{
    public class UserRolesViewModel
    {
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public Dictionary<IdentityRole,bool> Roles { get; set; }
    }
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ApplicationUser>  AppUsers { get; set; }
    }
}
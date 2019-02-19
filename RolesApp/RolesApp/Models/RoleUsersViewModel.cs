using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolesApp.Models
{
    public class RoleUsersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
    public class UserInRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public string UserId { get; set; }
    }
}
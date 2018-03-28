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
}
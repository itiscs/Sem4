﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiIdentity2.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Age { get; set; }


    }
}

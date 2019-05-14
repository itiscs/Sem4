using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Model
{
    public class UsersContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Score> Scores { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        { }

    }
}

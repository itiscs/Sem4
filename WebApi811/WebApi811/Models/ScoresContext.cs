using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi811.Models
{
    public class ScoresContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Score> Scores { get; set; }
        public ScoresContext(DbContextOptions<ScoresContext> options)
            : base(options)
        { }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi809.Models
{
    public class ScoresDB : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Score> Scores { get; set; }
        public ScoresDB(DbContextOptions<ScoresDB> options)
            : base(options)
        { }

    }
}

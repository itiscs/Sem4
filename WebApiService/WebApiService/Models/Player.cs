using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiService.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public DateTime ScoreDate { get; set; }
    }

    public class ScoresDB:DbContext
    {
        public ScoresDB():base("ScoresDB")
        {
        }

        public DbSet<Player> Players { get; set; }
        

    }


}
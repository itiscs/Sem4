using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi809.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ScoreDate { get; set; }
        public int UserScore { get; set; }

    }
}

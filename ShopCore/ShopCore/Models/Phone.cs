using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCore.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

    public class ShopDB:DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public ShopDB(DbContextOptions<ShopDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


    }



}

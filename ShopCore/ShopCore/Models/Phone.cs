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
            if(Phones.Count()==0)
            {
                Phones.Add(new Phone() {
                    Brand ="IPhone",
                    Model ="XS MAX",
                    Price = 90000m,
                    Image = @"/images/iphone-xs-max.jpg"
                });
                Phones.Add(new Phone()
                {
                    Brand = "Samsung",
                    Model = "Galaxy S10",
                    Price = 60000m,
                    Image = @"/images/samsung-galaxy-s10.jpg"
                });
                SaveChanges();

            }
        }


    }



}

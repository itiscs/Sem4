using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class EShopInitializer: DropCreateDatabaseIfModelChanges<EShopDB>
    {
        protected override void Seed(EShopDB context)
        {
            var phones = new List<Phone>
            {
                new Phone(){Brand="IPhone", Model="X", Price=90m,
                             Amount=100, ImageFile="Iphone.png" },
                new Phone(){Brand="Samsung", Model="Galaxy 9", Price=65m,
                             Amount=100, ImageFile="Samsung.png" },
                new Phone(){Brand="Xaomi", Model="Mi 6", Price=35m,
                             Amount=100, ImageFile="xiaomi.png" },
            };

            phones.ForEach(p => context.Phones.Add(p));
            context.SaveChanges();
        }
    }



    public class EShopDB:DbContext
    {
        public EShopDB():base("EShopDB")
        {

        }

        public DbSet<Phone> Phones { get; set; }
    }
}
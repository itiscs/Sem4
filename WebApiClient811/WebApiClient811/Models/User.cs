using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClient811.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name="Возраст")]
        [Range(0,100)]
        public int Age { get; set; }

    }
}

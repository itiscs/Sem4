using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    [Table("Student2")]
    public class Student
    {
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        [Display(Name ="Фамилия")]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Имя")]
        public string FirstMidName { get; set; }
        [Display(Name = "Дата записи")]
        public DateTime EnrollmentDate { get; set; }
        public string ImageFile { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
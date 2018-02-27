using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [Range(typeof(decimal),"0","100",ErrorMessage ="Значение должно быть от 0 до 100")]
        public decimal Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
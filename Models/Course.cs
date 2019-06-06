using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace ANVBookstore.Models
{
    public partial class Course
    {
        public Course()
        {
            Textbook = new HashSet<Textbook>();
        }

        public string CourseId { get; set; }
        [Required(ErrorMessage = "Please Enter a Course Name")]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please Enter a Course Professor")]
        [MaxLength(50)]
        public string CourseProf { get; set; }

        public virtual ICollection<Textbook> Textbook { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Course
    {
        [Key]
        public int Course_ID { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course Alias")]
        public string CourseAlias { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual ICollection<Standard> Standards { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Student_Status
    {
        [Key]
        [Display(Name = "Status")]
        public int Student_Status_ID { get; set; }

        [Required]
        [Display(Name = "Student Status")]
        public string StudentStatus { get; set; }

    }
}
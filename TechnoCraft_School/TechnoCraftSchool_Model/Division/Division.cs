using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Division
    {
        [Key]
        public int Division_ID { get; set; }

        //[ForeignKey("Class_ID")]
        [Required]
        public int Class_ID { get; set; }

        [Required]
        [Display(Name="Division Name")]
        public string DivisionName { get; set; }

        [Required]
        [Display(Name = "Division Alias")]
        public string DivisionAlias { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual Class Classs { get; set; }
    }
}
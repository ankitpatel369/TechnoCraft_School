using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class AcademicYear
    {
        [Key]
        public int AcademicYear_Id { get; set; }

        [Required]
        [Display(Name = "Academic Period Name")]
        public string AcademicPeriodName { get; set; }

        [Required]
        [Display(Name = "Academic Period Alias")]
        public string AcademicPeriodAlias { get; set; }

        [Required]
        [Display(Name = "Starting Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public string StartingDate { get; set; }

        [Required]
        [Display(Name = "Ending Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public string EndingDate { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}
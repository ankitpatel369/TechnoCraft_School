using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TechnoCraftSchool_Model.Core;

namespace TechnoCraftSchool_Model
{
    public class Institute : BaseModel
    {
        //[Key]
        //public int Institution_Id { get; set; }

        [Required]
        [Display(Name = "Institution Name")]
        public string InstitutionName { get; set; }
        
        [Required]
        [Display(Name = "Institution Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Institution Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Institution Phone No")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Institution Mobile No")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Admin Contact Person")]
        public string AdminContact { get; set; }
        
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Institution Code")]
        public string InstitutionCode { get; set; }

        //[Required]
        //[Display(Name = "Time Zone")]
        //[DataType(DataType.Time)]
        //public TimeZone Time_Zone { get; set; }
    }
}
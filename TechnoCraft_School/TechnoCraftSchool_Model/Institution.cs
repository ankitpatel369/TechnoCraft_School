using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Institution
    {
        [Key]
        public int Institution_Id { get; set; }

        [Required]
        [Display(Name = "Institution Name")]
        public string InstitutionName { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone No.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Mobile No.")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name="Admin Contact No.")]
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

        [Required]
        [Display(Name = "Time Zone")]
        public TimeZone Time_Zone { get; set; }
    }
}
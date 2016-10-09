using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Admission_Additional_Info
    {
        [Key]
        public int Admission_Additional_Info_ID { get; set; }

        public int Admission_ID { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date_of_Birth { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "Mother Tongue")]
        public string MotherTongue { get; set; }

        [Required]
        [Display(Name = "Religion")]
        public string Religion { get; set; }

        [Required]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string PermanentCity { get; set; }

        [Required]
        [Display(Name = "Taluka")]
        public string PermanentTaluka { get; set; }

        [Required]
        [Display(Name = "District")]
        public string PermanentDistrict { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public string PermanentPhone { get; set; }

        [Required]
        [Display(Name = "Local Address")]
        public string LocalAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string LocalCity { get; set; }

        [Required]
        [Display(Name = "Taluka")]
        public string LocalTaluka { get; set; }

        [Required]
        [Display(Name = "District")]
        public string LocalDistrict { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public string LocalPhone { get; set; }

        [Required]
        [Display(Name = "Student Phone No")]
        public string StudentPhone { get; set; }

        [Required]
        [Display(Name = "Father Phone No")]
        public string FatherPhone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "Caste")]
        public string CasteName { get; set; }

        public virtual Admissions Admission { get; set; }

    }
}
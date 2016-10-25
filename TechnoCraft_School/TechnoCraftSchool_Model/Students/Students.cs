using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Students
    {
        [Key, Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Students_ID { get; set; }

        //[Required]
        //public int Contact_ID { get; set; }

        [Required]
        [Display(Name = "General Register No")]
        //[Key, Column(Order = 1)]
        public long GR_No { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name ="Photo")]
        public string StudentPhoto { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public int Course_ID { get; set; }

        [Required]
        [Display(Name = "Standard Name")]
        public int Standard_ID { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public int Class_ID { get; set; }

        [Required]
        [Display(Name = "Division Name")]
        public int Division_ID { get; set; }
  
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime? Date_of_Birth { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Caste")]
        public string CasteName { get; set; }

        [Required]
        [Display(Name = "Caste Category")]
        public string CasteCategory { get; set; }

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
        [DataType(DataType.MultilineText)]
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
        [DataType(DataType.MultilineText)]
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
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        //[Required]
        [Display(Name = "Date Of Admission")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date_Of_Admission { get; set; }

        //[Required]
        [Display(Name = "Year Of Admission")]
        public string Year_Of_Admission { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Student_Status_ID { get; set; }

    }
}
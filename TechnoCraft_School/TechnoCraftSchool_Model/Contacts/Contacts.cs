using System.ComponentModel.DataAnnotations;

namespace TechnoCraftSchool_Model.Contacts
{
    public class Contacts
    {
        [Key]
        public int Contact_ID { get; set; }

        [Required]
        [Display(Name = "Student First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Cast")]
        public string Cast { get; set; }

        [Required]
        [Display(Name ="Is Active")]
        public int IsActive { get; set; }


    }
}
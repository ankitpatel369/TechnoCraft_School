using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechnoCraftSchool_Model
{
    public class Class
    {
        [Key]
        public int Class_ID { get; set; }

        //[ForeignKey("Standard_ID")]
        [Required]
        public int Standard_ID { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Required]
        [Display(Name = "Class Alias")]
        public string ClassAlias { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual Standard Standards { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }


    }
}
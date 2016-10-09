using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model
{
    public class Standard
    {
        [Key]
        public int Standard_ID { get; set; }

        //[ForeignKey("Course_ID")]
        [Required]
        public int Course_ID { get; set; }

        [Required]
        [Display(Name = "Standard Name")]
        public string StandardName { get; set; }

        [Required]
        [Display(Name = "Standard Alias")]
        public string StandardAlias { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
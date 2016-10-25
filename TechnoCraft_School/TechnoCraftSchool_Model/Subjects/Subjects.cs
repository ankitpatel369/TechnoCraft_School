using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoCraftSchool_Model.Subjects
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        public int Subject_ID { get; set; }
        
        [Required]
        [Display(Name ="Subject Name")]
        public string SubjectName { get; set; }
        
    }

    [Table("Subjectassign")]
    public class Subjectassign
    {
        [Key]
        public int Subjectassign_ID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int Course_ID { get; set; }

        [Required]
        [Display(Name = "Standard")]
        public int Standard_ID { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int Subject_ID { get; set; }
    }

    [Table("SubjectAllocation")]
    public class SubjectAllocation
    {
        [Key]
        public int SubjectAllocation_ID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int Course_ID { get; set; }

        [Required]
        [Display(Name = "Standard")]
        public int Standard_ID { get; set; }

        [Required]
        [Display(Name = "Class")]
        public int Class_ID { get; set; }

        [Required]
        [Display(Name = "Division")]
        public int Division_ID { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int Subject_ID { get; set; }

        [Display(Name = "Allocation Date")]
        [DataType(DataType.DateTime)]
        public DateTime? AllocationDate { get; set; }
    }
}
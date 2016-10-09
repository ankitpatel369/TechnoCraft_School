using System;
using System.ComponentModel.DataAnnotations;

namespace TechnoCraftSchool_Model.Core
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoCraftSchool_Model.Core.Attributes
{
    public class AgeValidatorAttribute : ValidationAttribute
    {
        public int MinAge { get; private set; }
        public int MaxAge { get; private set; }

        /// <summary>
        /// This loads default values form web.config file.
        /// </summary>
        public AgeValidatorAttribute()
        {
            MinAge = Convert.ToInt32(ConfigurationSettings.AppSettings["minAge"].ToString());
            MaxAge = Convert.ToInt32(ConfigurationSettings.AppSettings["maxAge"].ToString());
        }

        public AgeValidatorAttribute(int minAge, int maxAge)
        {
            MinAge = minAge;
            MaxAge = maxAge;
        }

        public override bool IsValid(object value)
        {
            try
            {
                int age = Convert.ToInt32(value);
                return (age >= MinAge && age <= MaxAge);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

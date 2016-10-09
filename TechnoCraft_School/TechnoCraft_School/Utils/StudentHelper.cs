using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnoCraft_School.Utils
{
    public class StudentHelper
    {
        public IEnumerable<SelectListItem> SelectBloodGroup()
        {
            List<SelectListItem> lstListItems = new List<SelectListItem>();
            foreach (var bType in BloodGroupTypes())
            {
                lstListItems.Add(new SelectListItem()
                {
                    Text = bType,
                    Value = bType
                });
            }
            return lstListItems;
        }

        public IEnumerable<string> BloodGroupTypes()
        {
            List<string> lstBloodGroup = new List<string>();
            lstBloodGroup.Add("A+");
            lstBloodGroup.Add("O+");
            lstBloodGroup.Add("B+");
            lstBloodGroup.Add("AB+");
            lstBloodGroup.Add("A-");
            lstBloodGroup.Add("B-");
            lstBloodGroup.Add("O-");
            lstBloodGroup.Add("AB-");
            return lstBloodGroup;
        }

        public IEnumerable<SelectListItem> SelectGender()
        {
            List<SelectListItem> lstListItems = new List<SelectListItem>();
            foreach (var gendertype in GenderType())
            {
                lstListItems.Add(new SelectListItem()
                {
                    Text = gendertype,
                    Value = gendertype
                });
            }
            return lstListItems;
        }
        public IEnumerable<string> GenderType()
        {
            List<string> lstGender = new List<string>();
            lstGender.Add("Male");
            lstGender.Add("Female");
            return lstGender;
        }
    }
}
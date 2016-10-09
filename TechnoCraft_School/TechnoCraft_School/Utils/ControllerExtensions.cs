using TechnoCraft_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnoCraft_School.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected void AddModelErrors()
        {
            List<string> errors = new List<string>();
            foreach (var modelStateKey in ModelState.Values)
            {
                foreach (var error in modelStateKey.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
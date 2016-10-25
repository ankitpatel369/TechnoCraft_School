using TechnoCraft_School.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TechnoCraft_School.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Adds model error related to specific modelstate
        /// </summary>
        protected string AddModelErrors(string ErrorMessage = "")
        {
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                errors.Add(ErrorMessage);
            }
            foreach (var item in ModelState.Keys)
            {
                foreach (var error in ModelState[item].Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return string.Join("\n", errors.ToArray());
        }
    }
}
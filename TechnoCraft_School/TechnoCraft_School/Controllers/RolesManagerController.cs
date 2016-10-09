using TechnoCraft_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TechnoCraft_School.Controllers
{
    [Authorize(Roles = "Global Admin")]
    public class RolesManagerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }


        // GET: RolesManager
        [Authorize]
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
        
        [Authorize]
        public ActionResult ManageUserRoles()
        {
            //db.Users.ToList();
            IEnumerable<ApplicationUser> Users = db.Users.ToList().Where(u => u.Id != User.Identity.GetUserId());
            SelectList s = new SelectList(Users, "Id", "UserName");
            ViewBag.UserName = s;
            
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName, string RoleName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = db.Users.Where(u => u.Id.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                string str = Request.Params["buttonGroup"];
                if (str.Equals("Add Role To User"))
                {
                    UserManager.AddToRole(user.Id, RoleName);
                }

                ViewBag.RolesForThisUser = UserManager.GetRoles(user.Id);

                List<ApplicationUser> Users = db.Users.ToList();
                SelectList s = new SelectList(Users, "Id", "UserName");
                ViewBag.UserName = s;


                // prepopulat roles for the view dropdown
                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
                ViewBag.User = UserName;
            }
            return View("ManageUserRoles");
        }

        [Authorize]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            ApplicationUser user = db.Users.Where(u => u.Id.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (UserManager.IsInRole(user.Id, RoleName))
            {
                if (!RoleName.Equals("Admin"))
                {
                    UserManager.RemoveFromRole(user.Id, RoleName);
                    ViewBag.SuccessMessage = "User role has been removed successfully";
                }
                else
                {
                    //UserManager.RemoveFromRole(user.Id, RoleName);
                    ViewBag.WarningMessage = "Admin can't change his own role !";
                }
            }
            else
            {
                ViewBag.WarningMessage = "This user not belongs to selected role.";
            }



            List<ApplicationUser> Users = db.Users.ToList();
            SelectList s = new SelectList(Users, "Id", "UserName");
            ViewBag.UserName = s;

            // prepopulat roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            ViewBag.RolesForThisUser = UserManager.GetRoles(user.Id);
            ViewBag.User = UserName;
            return View("ManageUserRoles");
        }

        [Authorize]
        public ActionResult UserInfo()
        {

            List<ApplicationUser> Users = db.Users.ToList();
            SelectList s = new SelectList(Users, "Id", "UserName");
            ViewBag.UserName = s;

            return View();
        }

    }
}

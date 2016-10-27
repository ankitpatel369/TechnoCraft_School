using TechnoCraft_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using TechnoCraft_School.Utils.Notification;

namespace TechnoCraft_School.Controllers
{
    [Authorize(Roles = "Global Admin")]
    public class RolesManagerController : ControllerBase
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
            private set { _userManager = value; }
        }
        // GET: RolesManager
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();

            SelectList s1 = new SelectList(db.Users.ToList(), "Id", "UserName");
            ViewBag.comboboxUsers = s1;

            SelectList s2 = new SelectList(db.Roles.ToList(), "Id", "Name");
            ViewBag.comboboxRoles = s2;

            return View(roles);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
                    (new RoleStore<IdentityRole>(new ApplicationDbContext()));
                if (!roleManager.RoleExists(collection["RoleName"]))
                {
                    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    {
                        Name = collection["RoleName"]
                    });
                    db.SaveChanges();
                    this.ShowMessage(MessageType.Success, "Roles added successfully.", true);
                }
                else
                {
                    this.ShowMessage(MessageType.Error, "Roles already exists.", true);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                this.ShowMessage(MessageType.Error, "Error occurred while adding Role.", true);
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        [AjaxMessagesFilter]
        public ActionResult Delete(string RoleName)
        {
            try
            {
                var thisRole = db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                db.Roles.Remove(thisRole);
                db.SaveChanges();
                this.ShowMessage(MessageType.Success, "Role is deleted.", true);
                return Json(true);
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error occurred while deleting Role.", true);
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult GetUserRoles(string userName)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var rolesForUser = userManager.GetRoles(userName);
                return Json(rolesForUser, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize]
        [AjaxMessagesFilter]
        public ActionResult DeleteUserRoles(string userName, string rolename)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                if (userManager.IsInRole(userName, rolename))
                {
                    userManager.RemoveFromRole(userName, rolename);
                }
                this.ShowMessage(MessageType.Success, "The Role has been deleted.");
                return Json(true);
            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, "Error while deleting role.");
                return Json(false);
            }
        }

        [Authorize]
        [AjaxMessagesFilter]
        public ActionResult AddUserRoles(string userName, string rolename)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                if (!userManager.IsInRole(userName, rolename))
                {
                    userManager.AddToRole(userName, rolename);
                    this.ShowMessage(MessageType.Success, "The Role has been added.");
                    return Json(true);
                }
                else
                {
                    this.ShowMessage(MessageType.Error, "This user already contains this role.");
                    return Json(false);
                }

            }
            catch (Exception ex)
            {
                this.ShowMessage(MessageType.Error, AddModelErrors(ex.Message));
                return Json(false);
            }
        }

    }
}

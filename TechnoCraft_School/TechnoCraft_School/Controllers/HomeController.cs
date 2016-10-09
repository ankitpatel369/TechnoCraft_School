using System.Web.Mvc;

namespace TechnoCraft_School.Controllers
{
//    [Authorize(Roles = "Global Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Support Details.";
            return View();
        }

        [ActionName(name: "ServerError")]
        public ActionResult Error()
        {
            return View("Error");
        }
        
        public ActionResult AuthorizeFailed()
        {
            return View("AuthorizeFailed");
        }

        [ActionName(name: "NotFound")]
        public ActionResult NotFound()
        {
            return View("NotFound");
        }
    }
}
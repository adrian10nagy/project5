using Business.Managers;
using Project5.WebSite.Helpers;
using System.Web.Mvc;

namespace Project5.WebSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var user = UsersManager.ValidateLogin(collection["loginUserEmail"], collection["loginUserPassword"]);

            if (user != null && user.Id > 0)
            {
                BaseMVC.setUser(user);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("userId");
            Session.Remove("userFirstName");
            Session.Remove("userLastName");
            Session.Remove("userType");

            BaseMVC.unsetUser();
            WebSite.Helpers.Web.Instance.Session.unsetUser();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AsyncUserLogin(string userEmail, string userPass)
        {
            var user = UsersManager.ValidateLogin(userEmail, userPass);

            if (user != null)
            {
                return Json(new { success = false });
            }

            if (user != null && user.Id > 0)
            {
                Session["userId"] = user.Id;
                Session["userType"] = (int)user.UserType;
                Session["userFirstName"] = user.FirstName;
                Session["userLastName"] = user.LastName;

                //Set login credentials
                BaseMVC.setUser(user);

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}
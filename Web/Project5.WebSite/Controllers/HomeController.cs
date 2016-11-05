
namespace Project5.WebSite.Controllers
{
    using Business.Managers;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var categories = CategoriesManager.GetAllWithProductType();
            ViewData["categories"] = categories;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
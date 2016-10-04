
namespace Project5.WebSite.Controllers
{
    using Business.Managers;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web.Mvc;

    public class ResourceController : Controller
    {
        // GET: Resource
        [HttpPost]
        public ActionResult AsyncFindSearch(string textSearch)
        {
            var allProductTypes = ProductsManager.GetProductsByNameLikeInput(textSearch);
            ViewData["allProductTypes"] = allProductTypes;

            return PartialView("_MainSearch");
        }

        //[HttpPost]
        //public ActionResult AsyncFindCountiesSearch(string textSearch)
        //{
        //    var allCounties = LocationManager.GetCountiesLikeInput(textSearch);
        //    ViewData["allCounties"] = allCounties;

        //    return PartialView("_CountiesSearch");
        //}

        public ActionResult GetImg(string imgPath)
        {
            var srcImage = Image.FromFile(imgPath);
            using (var streak = new MemoryStream())
            {
                srcImage.Save(streak, ImageFormat.Jpeg);
                return File(streak.ToArray(), "image/png");
            }
        }
    }
}
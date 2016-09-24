using Business.Managers;
using Project5.WebSite.Helpers;
using Project5.WebSite.Models;
using System.Web.Mvc;

namespace Project5.WebSite.Controllers
{
    public class OfferController : Controller
    {
        // GET: Offer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string mainSearch, string mainSearchCounties)
        {
            var searchView = new SearchView()
            {
                SearchCriterias = SearchCriteriasManager.GetAll(),
                ProductTypes = ProductsManager.GetProductTypesAll(),
                SearchedKey = mainSearch,
                OfferTypes = OffersManager.GetOfferTypesAll(),
                Offers = SearchManager.FindBySearchWord(mainSearch.ToLower()),
            };
            
            return View(searchView);
        }

        // GET: Offer
        public ActionResult Details(int id = 0)
        {
            if(id == 0)
            {
                id = 1;
            }

            var offer = OffersManager.GetById(id);
            var images = ProcessHelper.Instance.GetImagesPathsForOffer(offer.Id);
            ViewData["images"] = images;

            return View(offer);
        }
    }
}
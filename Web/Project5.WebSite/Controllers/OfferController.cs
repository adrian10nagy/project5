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
        public ActionResult Search(string mainSearchTxt, string dropdownSearchCountries, string dropdownSearchCategories)
        {
            var country = 0;
            int.TryParse(dropdownSearchCountries, out country);
            var category = 0;
            int.TryParse(dropdownSearchCategories, out category);
            mainSearchTxt = mainSearchTxt ?? string.Empty;
            var searchView = new SearchView()
            {
                Offers = SearchManager.FindBySearchWord(mainSearchTxt.ToLower(), category, country),
                OfferSuggestions = SearchManager.GetSuggestions(mainSearchTxt.ToLower(), category, country),
                SearchCriterias = SearchCriteriasManager.GetAll(),
                ProductTypes = ProductsManager.GetProductTypesAll(),
                SearchedKey = mainSearchTxt,
                OfferTypes = OffersManager.GetOfferTypesAll(),
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
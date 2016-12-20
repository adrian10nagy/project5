using Business.Managers;
using Project5.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5.WebSite.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Category(int id = 1)
        {
            var searchView = new SearchView()
            {
                SearchCriterias = SearchCriteriasManager.GetAll(),
                ProductTypes = ProductsManager.GetProductTypesByCategoryId(id),
                OfferTypes = OffersManager.GetOfferTypesAll(),
                Offers = SearchManager.GetSuggestionsByCategoryId(id)
            };

            return View(searchView);
        }

        [HttpGet]
        public ActionResult Offer(string mainSearchTxt, string dropdownSearchCountries, string dropdownSearchCategories)
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
    }
}
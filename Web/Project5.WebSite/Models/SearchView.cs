using DAL.Entities;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Project5.WebSite.Models
{
    public class SearchView
    {
        public List<SearchCriteria> SearchCriterias { get; set; }

        public List<ProductType> ProductTypes { get; set; }

        public List<Offer> Offers { get; set; }

        public string SearchedKey { get; set; }

        public List<OfferType> OfferTypes { get; set; }

        public List<Image> Images { get; set; } 
    }
}
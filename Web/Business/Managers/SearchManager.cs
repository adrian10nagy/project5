using DAL.Entities;
using DAL.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public static class SearchManager
    {
        public static List<Offer> FindBySearchWord(string searchTerm)
        {
            List<Offer> offers = new List<Offer>();
            
            // add offers if keyword is Product (ex: Mere, Covor)
            var productsByType = ProductsManager.GetProductsByNameLikeInput(searchTerm);
            if(productsByType.Count > 0)
            {
                offers.AddRange(OffersManager.GetByProductType(productsByType[0].ProductType.Id));
            }

            // add offers if keyword is Product Type (ex: Legume, Fructe)
            var productsByName = ProductsManager.GetProductsByProductTypesLikeInput(searchTerm);
            if(productsByName.Count > 0)
            {
                offers.AddRange(OffersManager.GetByProductType(productsByName[0].Id));
            }

            // add offer if keyword is in offer name 
            if (offers.Count < 25)
            {
                offers.AddRange(OffersManager.GetBySearchInputOnTitle(searchTerm));
            }

            offers = offers.GroupBy(x => x.Id).Select(x => x.First()).ToList();

            return offers;
        }
    }
}

using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SDK
{
    public class Offers
    {
        private static IOfferRepository _repository;

        static Offers()
        {
            _repository = new Repository();
        }

        #region Get

        public Offer GetOfferById(int id)
        {
            return _repository.GetOfferById(id);
        }

        public List<Offer> GetOffersAll()
        {
            return _repository.GetOffersAll();
        }

        #endregion

        public List<OfferType> GetOfferTypesAll()
        {
            return _repository.GetOfferTypesAll();
        }

        public List<Offer> GetOffersByProductType(int productType)
        {
            return _repository.GetOffersByProductType(productType);
        }
    }
}
﻿
namespace Business.Managers
{
    using Business.Cache;
    using DAL.Entities;
    using DAL.SDK;
    using System.Collections.Generic;

    public static class OffersManager
    {
        public static List<Offer> GetAll()
        {
            var offers = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheOffersAll) as List<Offer>;

            if (offers == null)
            {
                offers = Kit.Instance.Offers.GetOffersAll();

                MyCache.Instance.AddToMyCache(CacheConstants.CacheOffersAll, offers, MyCachePriority.Default);
            }

            return offers;
        }

        public static List<Offer> GetBySearchInputOnTitle(string input)
        {
            var result = GetAll();
            if (input != null && !input.Equals(""))
            {
                result = result.FindAll(x => x.Title.ToLower().Contains(input));
            }

            return result;
        }

        public static List<Offer> GetByProductType(int productType)
        {
            return Kit.Instance.Offers.GetOffersByProductType(productType);
        }

        public static List<Offer> GetByCategoryId(int categoryId)
        {
            var offers = new List<Offer>();
            var productTypes = Kit.Instance.Products.GetProductTypesByCategoryId(categoryId);
            foreach (var type in productTypes)
            {
                offers.AddRange(OffersManager.GetByProductType(type.Id));
            }

            return Kit.Instance.Offers.GetOffersByProductType(categoryId);
        }

        public static Offer GetById(int id)
        {
            return Kit.Instance.Offers.GetOfferById(id);
        }

        public static List<OfferType> GetOfferTypesAll()
        {
            var offerTypes = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheOfferTypesAll) as List<OfferType>;

            if (offerTypes == null)
            {
                offerTypes = Kit.Instance.Offers.GetOfferTypesAll();

                MyCache.Instance.AddToMyCache(CacheConstants.CacheOfferTypesAll, offerTypes, MyCachePriority.Default);
            }

            return offerTypes;
        }

        public static void Update(Offer offer)
        {
            Kit.Instance.Offers.Update(offer);
        }

        public static void Inset(Offer offer)
        {
            throw new System.NotImplementedException();
        }
    }
}

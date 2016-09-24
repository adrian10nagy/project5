using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public interface IOfferRepository
    {
        Offer GetOfferById(int id);
        List<Offer> GetOffersAll();
        List<OfferType> GetOfferTypesAll();
        List<Offer> GetOffersByProductType(int productType);
    }

    public partial class Repository : IOfferRepository
    {
        #region Get

        public Offer GetOfferById(int id)
        {
            Offer offer = null;

            _dbRead.Execute(
                "OfferGetById",
            new[] { 
                new SqlParameter("@Id", id), 
            },
                r => offer = new Offer()
                {
                    Id = Read<int>(r, "Id"),
                    Description = Read<string>(r, "Description"),
                    Title = Read<string>(r, "Title"),
                    Price = Read<int>(r, "Price"),
                    Created = Read<DateTime>(r, "Created"),
                    OfferType = (OfferType)Read<int>(r, "Id_Typ"),
                    Product = new Product()
                    {
                        Id = Read<int>(r, "Id_Prd")
                    }
                });

            return offer;
        }

        public List<Offer> GetOffersAll()
        {
            var offers = new List<Offer>();

            _dbRead.Execute(
                "OffersGetAll",
            null,
                r => offers.Add(new Offer()
                {
                    Id = Read<int>(r, "Id"),
                    Description = Read<string>(r, "Description"),
                    Title = Read<string>(r, "Title"),
                    Price = Read<int>(r, "Price"),
                    Created = Read<DateTime>(r, "Created"),
                    OfferType = (OfferType)Read<int>(r, "Id_Typ"),
                    Flags = (OfferFlags)Read<int>(r, "Flags"),
                    Product = new Product()
                    {
                        Id = Read<int>(r, "Id_Prd")
                    }
                }));

            return offers;
        }

        public List<OfferType> GetOfferTypesAll()
        {
            var productTypes = new List<OfferType>();

            _dbRead.Execute(
                "OfferTypesGetAll",
            null,
                r => productTypes.Add(
                    (OfferType)Read<int>(r, "Id")
                ));

            return productTypes;
        }

        public List<Offer> GetOffersByProductType(int productTypeId)
        {
            var offers = new List<Offer>();

            _dbRead.Execute(
                "OffersGetByProductType",
                new[] { 
                    new SqlParameter("@Id_productType", productTypeId), 
                },            
                r => offers.Add(new Offer()
                {
                    Id = Read<int>(r, "Id"),
                    Description = Read<string>(r, "Description"),
                    Title = Read<string>(r, "Title"),
                    Price = Read<int>(r, "Price"),
                    Created = Read<DateTime>(r, "Created"),
                    OfferType = (OfferType)Read<int>(r, "Id_Typ"),
                    Product = new Product()
                    {
                        Id = Read<int>(r, "Id_Prd")
                    }
                 }
                ));

            return offers;
        }
        #endregion
    }
}

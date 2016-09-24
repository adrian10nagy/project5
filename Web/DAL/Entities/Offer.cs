
namespace DAL.Entities
{
    using System;

    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Price { get; set; }
        public OfferType OfferType { get; set; }
        public Product Product { get; set; }
        public Company Conpany { get; set; }
        public OfferFlags Flags { get; set; }
    }

    public enum OfferType
    {
        None = 0,
        Vânzare = 1,
        Schimb = 2,
        Donație = 3
    }

    [Flags]
    public enum OfferFlags
    {
        IsNotApproved = 1,
        IsDeleted  = 2,
        IsBlocked = 4
    }
}

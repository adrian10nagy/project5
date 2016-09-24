using Business.Managers;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Project5.WebSite.Helpers
{
    public class CartHelper : Controller
    {

        public int LastCartOfferId(string sessionId)
        {
            if (System.Web.HttpContext.Current.Session["sessionId" + sessionId + "lastCartId"] == null ||
                int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "lastCartId"].ToString()) == 0)
            {
                return 0;
            }

            return int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "lastCartId"].ToString());
        }

        private void IncrementLastCartId(string sessionId)
        {
            var lastCartId = LastCartOfferId(sessionId) + 1;
            System.Web.HttpContext.Current.Session["sessionId" + sessionId + "lastCartId"] = lastCartId;

        }

        public void AddToCart(CartOffer cartOffer)
        {
            var lastCartOfferId = LastCartOfferId(cartOffer.SessionId) + 1;
            System.Web.HttpContext.Current.Session["sessionId" + cartOffer.SessionId + "offerId" + lastCartOfferId.ToString()] = cartOffer.Offer.Id;
            System.Web.HttpContext.Current.Session["sessionId" + cartOffer.SessionId + "offerId" + lastCartOfferId.ToString() + "quantity"] = cartOffer.Quantity;
            IncrementLastCartId(cartOffer.SessionId);
        }

        public Cart GetCartBySessionId(string sessionId)
        {
            var cart = new Cart()
            {
                CartOffers = new List<CartOffer>()
            };

            var lastCartOfferId = LastCartOfferId(sessionId) + 1;
            for (int i = 0; i < lastCartOfferId; i++)
            {
                var cartOffer = GetCartOfferByIdAndSessionId(sessionId, i);
                if(cartOffer != null)
                {
                    cart.CartOffers.Add(cartOffer);
                }
            }

            return cart;
        }

        private CartOffer GetCartOfferByIdAndSessionId(string sessionId, int i)
        {
            CartOffer cartOffer = null;

            if (System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i] != null &&
                int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i].ToString()) != 0)
            {
                if (System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i + "quantity"] != null &&
                    int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i + "quantity"].ToString()) != 0)
                {
                    cartOffer = new CartOffer();
                    cartOffer.Offer = OffersManager.GetById(int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i].ToString()));
                    cartOffer.Quantity = int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i + "quantity"].ToString());
                }
            }

            return cartOffer;
        }
    }
}

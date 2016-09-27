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

        public void AddToCart(OrderItem cartOffer)
        {
            var lastCartOfferId = LastCartOfferId(cartOffer.SessionId) + 1;
            System.Web.HttpContext.Current.Session["sessionId" + cartOffer.SessionId + "offerId" + lastCartOfferId.ToString()] = cartOffer.OfferId;
            System.Web.HttpContext.Current.Session["sessionId" + cartOffer.SessionId + "offerId" + lastCartOfferId.ToString() + "quantity"] = cartOffer.Quantity;
            IncrementLastCartId(cartOffer.SessionId);
        }

        public OrderItem GetLastItemInCart(string sessionId)
        {
            var cart = GetCartBySessionId(sessionId);
            return cart.Last();
        }

        public List<OrderItem> GetCartBySessionId(string sessionId)
        {
            var cartOffers = new List<OrderItem>();

            var lastCartOfferId = LastCartOfferId(sessionId) + 1;
            for (int i = 0; i < lastCartOfferId; i++)
            {
                var cartOffer = GetCartOfferByIdAndSessionId(sessionId, i);
                if(cartOffer != null)
                {
                    cartOffer.Offer = OffersManager.GetById(cartOffer.OfferId);
                    cartOffers.Add(cartOffer);
                }
            }

            return cartOffers;
        }

        private OrderItem GetCartOfferByIdAndSessionId(string sessionId, int i)
        {
            OrderItem cartOffer = null;

            if (System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i] != null &&
                int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i].ToString()) != 0)
            {
                if (System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i + "quantity"] != null &&
                    int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i + "quantity"].ToString()) != 0)
                {
                    cartOffer = new OrderItem();
                    cartOffer.OfferId = int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i].ToString());
                    cartOffer.Quantity = int.Parse(System.Web.HttpContext.Current.Session["sessionId" + sessionId + "offerId" + i + "quantity"].ToString());
                }
            }

            return cartOffer;
        }
    }
}

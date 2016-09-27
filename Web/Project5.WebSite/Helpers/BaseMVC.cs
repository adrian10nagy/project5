using DAL.Entities;
using System.Collections.Generic;

namespace Project5.WebSite.Helpers
{
    public interface ISession
    {
        // TO Be implemented properly
    }

    public class BaseMVC
    {
        private static User _instance = new User();
        public static User User;

        static User getInstance()
        {
            return WebSite.Helpers.Web.Instance.Session.User();
        }

        public static bool IsLoggedIn()
        {
            User = getInstance();
            if (User == null)
            {
                return false;
            }

            return true;
        }

        public static bool IsAdmin()
        {
            if (!IsLoggedIn())
                return false;

            if (User.UserType == UserType.Admin)
            {
                return true;
            }
            return false;
        }

        public static User getUser()
        {
            if (!IsLoggedIn())
            {
                return null;
            }

            return User;
        }

        public static int getUserId()
        {
            if (!IsLoggedIn())
            {
                return 0;
            }

            return User.Id;
        }

        public static void setUser(User user)
        {
            WebSite.Helpers.Web.Instance.Session.setUser(user);
        }

        public static void unsetUser()
        {
            WebSite.Helpers.Web.Instance.Session.unsetUser();
        }

        public static void AddToCart(OrderItem cartOffer)
        {
            cartOffer.SessionId = WebSite.Helpers.Web.Instance.Session.GetSessionId();
            WebSite.Helpers.Web.Instance.Cart.AddToCart(cartOffer);
        }

        public static List<OrderItem> GetCart()
        {
            string sessionId = WebSite.Helpers.Web.Instance.Session.GetSessionId();
            var cart =  WebSite.Helpers.Web.Instance.Cart.GetCartBySessionId(sessionId);

            return cart;
        }

        public static OrderItem GetLastItemInCart()
        {
            string sessionId = WebSite.Helpers.Web.Instance.Session.GetSessionId();
            var cart = WebSite.Helpers.Web.Instance.Cart.GetLastItemInCart(sessionId);

            return cart;
        }

        public static string GetSessionId()
        {
            var sessionId = WebSite.Helpers.Web.Instance.Session.GetSessionId();

            return sessionId;
        }
    }
}
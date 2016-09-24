﻿
namespace Project5.WebSite.Controllers
{
    using Business.Managers;
    using DAL.Entities;
    using Project5.WebSite.Helpers;
    using System;
    using System.Web.Mvc;

    public class CartController : Controller
    {
        public ActionResult Index()
        {
            var cart = BaseMVC.GetCart();
            var counties = LocationManager.GetAllCounties();

            ViewData["counties"] = counties;
            return View(cart);
        }

        [HttpPost]
        public ActionResult Confirm(FormCollection collection)
        {
            var email = collection["email"];

            var user = UsersManager.GetByEmail(email);

            if(user == null)
            {
                var userToAdd = new User
                {
                    FirstName = collection["firstname"],
                    LastName = collection["lastname"],
                    JoinDate = DateTime.Now,
                    Email = email,
                    PasswordHashed = "parola",
                    UserType = UserType.Member
                };
                UsersManager.Insert(userToAdd);
                user = userToAdd;
            }

            Order o = new Order
            {
                Address = collection["address"],
                City = collection["city"],
                County = new County
                {
                    Id = (int.Parse(collection["county"]))
                },
                DeliveryNotes = collection["deliverynotes"],
                User = new User
                {
                    Id = 1
                }
            };

            return View();
        }

        [HttpPost]
        public ActionResult AsyncAddToCart(int offerId)
        {
            var cartOffer = new CartOffer()
            {
                Offer = OffersManager.GetById(offerId),
                Quantity = 1
            };

            BaseMVC.AddToCart(cartOffer);

            return Json(new { isLoggedIn = false });

        }

        //action for modal popup
        public ActionResult _AddToCart()
        {
            var cart = BaseMVC.GetCart();

            return PartialView("_AddToCart", cart);
        }
    }
}
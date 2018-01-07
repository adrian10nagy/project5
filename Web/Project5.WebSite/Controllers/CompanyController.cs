using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Models;
using Business.Managers;

namespace Project5.WebSite.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetCompaniesPosition()
        {
            var result = new List<MapMark>();
            
            var companies = CompaniesManager.GetAll();
            foreach (var item in companies)
	        {
		        var mapMark = new MapMark
                {
                    LatLng = CompaniesManager.GetLatLng(item.AddressJSON),
                    Title = item.Name
                };

                if (mapMark.LatLng != null)
                {
                    result.Add(mapMark);
                }
	        }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
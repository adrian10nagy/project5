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
            var result = new List<MapMark>()
           {//45.95, lng: 24.95
             new MapMark
             { 
                LatLng = new LatLng
                {  
                    lat = 45.95, 
                    lng= 24.925 
                }
             },
             new MapMark
             { 
                 LatLng = new LatLng
                 {
                     lat = 45.195, 
                     lng= 24.955 
                 }
             },
             new MapMark
             { 
                 LatLng = new LatLng
                 {
                     lat = 45.95, 
                     lng= 24.95 
                 }
             },
             new MapMark
             { 
                 LatLng = new LatLng
                 {
                     lat = 45.1195, 
                     lng= 24.9355 
                 }
             },
           };
            
            var companies = CompaniesManager.GetAll();
            foreach (var item in companies)
	        {
		        var mapMark = new MapMark
                {
                    LatLng = CompaniesManager.GetLatLng(item.AddressXml),
                    Title = item.Name
                };
                result.Add(mapMark);
	        }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
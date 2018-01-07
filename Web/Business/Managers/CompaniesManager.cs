namespace Business.Managers
{
    using Business.Models;
    using DAL.Entities;
    using DAL.SDK;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Xml;

    public static class CompaniesManager
    {
        public static List<Company> GetAll()
        {
            return Kit.Instance.Companies.GetCompaniesAll();
        }

        public static Company GetById(int id)
        {
            return Kit.Instance.Companies.GetCompanyById(id);
        }

        public static void Insert(Company company)
        {
            Kit.Instance.Companies.InsertCompany(company);
        }

        public static void Update(Company company)
        {
            Kit.Instance.Companies.UpdateCompany(company);
        }

        public static LatLng GetLatLng(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }

            var latlng = new LatLng();
            JObject obj = JObject.Parse(jsonString);
            var lat = obj["results"][0]["geometry"]["location"]["lat"].ToString();
            var lng = obj["results"][0]["geometry"]["location"]["lng"].ToString();
            double latValue;
            double.TryParse(lat, out latValue);
            double lngValue;
            double.TryParse(lng, out lngValue);

            latlng.lat = latValue;
            latlng.lng = lngValue;

            return latlng;
        }
    }
}

namespace Business.Managers
{
    using Business.Models;
    using DAL.Entities;
    using DAL.SDK;
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

        public static LatLng GetLatLng(XmlDocument xmlDocument)
        {
            var latlng = new LatLng();

            throw new System.NotImplementedException();

            return latlng;
        }
    }
}

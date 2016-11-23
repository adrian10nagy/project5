namespace Business.Managers
{
    using DAL.Entities;
    using DAL.SDK;
    using System.Collections.Generic;

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
    }
}

using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SDK
{
    public class Companies
    {
        private static ICompanyRepository _repository;

        static Companies()
        {
            _repository = new Repository();
        }

        public List<Company> GetCompaniesAll()
        {
            return _repository.GetCompanyAll();
        }

        public Company GetCompanyById(int id)
        {
            return _repository.GetCompanyById(id);
        }

        public void InsertCompany(Company company)
        {
            _repository.InsertCompany(company);
        }

        public void UpdateCompany(Company company)
        {
            _repository.UpdateCompany(company);
        }
    }
}

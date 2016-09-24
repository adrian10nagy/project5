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

        public List<Company> GetOffersAll()
        {
            return _repository.GetCompanyAll();
        }
    }
}

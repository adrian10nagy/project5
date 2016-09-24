using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SDK
{
    public class SearchCriterias
    {
        private static ISearchCriteriaRepository _repository;

        static SearchCriterias()
        {
            _repository = new Repository();
        }

        public List<SearchCriteria> GetSearchCriteriaAll()
        {
            return _repository.GetSearchCriteriaAll();
        }
    }
}

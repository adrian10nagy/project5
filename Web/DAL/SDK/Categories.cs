using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SDK
{
    public class Categories
    {
        private static ICategoryRepository _repository;

        static Categories()
        {
            _repository = new Repository();
        }

        public List<Category> GetOffersAll()
        {
            return _repository.GetCategoryAll();
        }
    }
}

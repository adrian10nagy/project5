using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SDK
{
   public class Products
    {
        private static IProductRepository _repository;

        static Products()
        {
            _repository = new Repository();
        }

        #region Get

        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
       
        public List<Product> GetProductsAll()
        {
            return _repository.GetProductsAll();
        }

        public List<ProductType> GetProductTypesAll()
        {
            return _repository.GetProductTypesAll();
        }

        #endregion
    }
}

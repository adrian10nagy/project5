namespace DAL.SDK
{
    using DAL.Entities;
    using DAL.Repositories;
    using System.Collections.Generic;

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

        public List<ProductType> GetProductTypesByCategoryId(int id)
        {
            return _repository.GetProductTypesByCategoryId(id);
        }

        #endregion

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }

        public void InsertProduct(Product product)
        {
            _repository.InsertProduct(product);
        }
    }
}

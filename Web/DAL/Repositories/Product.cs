using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        List<Product> GetProductsAll();
        List<ProductType> GetProductTypesAll();
    }

    public partial class Repository : IProductRepository
    {
        #region Get

        public Product GetProductById(int id)
        {
            Product product = null;

            _dbRead.Execute(
                "ProductGetById",
            new[] { 
                new SqlParameter("@Id", id), 
            },
                r => product = new Product()
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                    ProductType = new ProductType
                    {
                        Id = Read<int>(r, "Id_PrdType"),
                        Name = Read<string>(r, "Prd_Name")
                    }
                });

            return product;
        }

        public List<Product> GetProductsAll()
        {
            var products = new List<Product>();

            _dbRead.Execute(
                "ProductsGetAll",
            null,
                r => products.Add(new Product()
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                    ProductType = new ProductType
                    {
                        Id = Read<int>(r, "Id_PrdType"),
                        Name = Read<string>(r, "Prd_Name")
                    }
                }));

            return products;
        }

        #endregion

        #region ProductTypes

        public List<ProductType> GetProductTypesAll()
        {
            var productTypes = new List<ProductType>();

            _dbRead.Execute(
                "ProductTypesGetAll",
            null,
                r => productTypes.Add(new ProductType
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "TypeName"),
                    CategoryId = Read<int>(r, "Id_ctg")
                }));

            return productTypes;
        }



        #endregion

    }
}

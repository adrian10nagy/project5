namespace DAL.Repositories
{
    using DAL.Cache;
    using DAL.Entities;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public interface IProductRepository
    {
        Product GetProductById(int id);
        List<Product> GetProductsAll();
        List<ProductType> GetProductTypesAll();
        List<ProductType> GetProductTypesByCategoryId(int id);
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
            var products = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheProductsAll) as List<Product>;

            if (products == null)
            {
                products = new List<Product>();

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

                MyCache.Instance.AddToMyCache(CacheConstants.CacheProductsAll, products, MyCachePriority.Default);
            }

            return products;
        }

        #endregion

        #region ProductTypes

        public List<ProductType> GetProductTypesAll()
        {
            var productTypes = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheProductTypesAll) as List<ProductType>;

            if (productTypes == null)
            {
                productTypes = new List<ProductType>();

                _dbRead.Execute(
                    "ProductTypesGetAll",
                null,
                    r => productTypes.Add(new ProductType
                    {
                        Id = Read<int>(r, "Id"),
                        Name = Read<string>(r, "TypeName"),
                        CategoryId = Read<int>(r, "Id_ctg")
                    }));

                MyCache.Instance.AddToMyCache(CacheConstants.CacheProductTypesAll, productTypes, MyCachePriority.Default, new System.TimeSpan(0, 5, 0));
            }

            return productTypes;
        }

        public List<ProductType> GetProductTypesByCategoryId(int id)
        {
            var productTypes = MyCache.Instance.GetMyCachedItem(string.Format(CacheConstants.CacheProductTypesByCategoryId, id)) as List<ProductType>;

            if (productTypes == null)
            {
                productTypes = new List<ProductType>();

                _dbRead.Execute(
                "ProductTypesGetByCategoryId",
                new[]
                {
                    new SqlParameter("@Id_ctg",id)
                },
                r => productTypes.Add(new ProductType
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "TypeName"),
                }));

                MyCache.Instance.AddToMyCache(CacheConstants.CacheProductTypesAll, productTypes, MyCachePriority.Default, new System.TimeSpan(0, 5, 0));
            }

            return productTypes;
        }

        #endregion

    }
}

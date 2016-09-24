
namespace Business.Managers
{
    using Business.Cache;
    using DAL.Entities;
    using DAL.SDK;
    using System.Collections.Generic;
    using System.Linq;

    public static class ProductsManager
    {
        public static List<Product> GetAll()
        {
            return Kit.Instance.Products.GetProductsAll();
        }

        public static List<Product> GetProductsByNameLikeInput(string input)
        {
            var result = GetAll();
            if (input != null && !input.Equals(""))
            {
                result = result.Where(p => p.Name.ToLower().Contains(input)).ToList();
            }
            return result;
        }

        public static List<ProductType> GetProductsByProductTypesLikeInput(string input)
        {
            var result = GetProductTypesAll();
            if (input != null && !input.Equals(""))
            {
                result = result.Where(p => p.Name.ToLower().Contains(input)).ToList();
            }
            return result;
        }

        public static List<ProductType> GetProductTypesAll()
        {
            var productTypes = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheProductTypesAll) as List<ProductType>;

            if (productTypes == null)
            {
                productTypes = Kit.Instance.Products.GetProductTypesAll();
                productTypes.OrderBy(o => o.Name);

                MyCache.Instance.AddToMyCache(CacheConstants.CacheProductTypesAll, productTypes, MyCachePriority.Default);
            }

            return productTypes;
        }
    }
}

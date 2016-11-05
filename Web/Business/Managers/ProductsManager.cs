
namespace Business.Managers
{
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
            var productTypes = Kit.Instance.Products.GetProductTypesAll();
            productTypes.OrderBy(o => o.Name);


            return productTypes;
        }

        public static List<ProductType> GetProductTypesByCategoryId(int id)
        {
            var productTypes = Kit.Instance.Products.GetProductTypesByCategoryId(id);
            productTypes.OrderBy(o => o.Name);

            return productTypes;
        }
    }
}

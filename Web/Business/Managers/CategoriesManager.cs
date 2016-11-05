using DAL.Entities;
using DAL.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public static class CategoriesManager
    {
        public static List<Category> GetAll()
        {
            return Kit.Instance.Categories.GetCategoryAll();
        }

        public static List<Category> GetAllWithProductType()
        {
            var categories =  Kit.Instance.Categories.GetCategoryAll();

            foreach (var item in categories)
            {
                item.ProductTypes = Kit.Instance.Products.GetProductTypesByCategoryId(item.Id);
            }

            return categories;
        }
    }
}

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
            return Kit.Instance.Categories.GetOffersAll();
        }
    }
}

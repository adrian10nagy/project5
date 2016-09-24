using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategoryAll();
    }

    public partial class Repository : ICategoryRepository
    {
        public List<Category> GetCategoryAll()
        {
            var productTypes = new List<Category>();

            _dbRead.Execute(
                "CategoryGetAll",
            null,
                r => productTypes.Add(new Category
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                }));

            return productTypes;
        }
    }
}

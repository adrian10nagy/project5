using DAL.Cache;

namespace DAL.Repositories
{
    using DAL.Entities;
    using System.Collections.Generic;

    public interface ICategoryRepository
    {
        List<Category> GetCategoryAll();
    }

    public partial class Repository : ICategoryRepository
    {
        public List<Category> GetCategoryAll()
        {
            var categories = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheCategoriesAll) as List<Category>;

            if (categories == null)
            {
                categories = new List<Category>();

                _dbRead.Execute(
                "CategoryGetAll",
            null,
                r => categories.Add(new Category
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                }));

                MyCache.Instance.AddToMyCache(CacheConstants.CacheCategoriesAll, categories, MyCachePriority.Default, new System.TimeSpan(0, 5, 0));
            }

            return categories;
        }
    }
}

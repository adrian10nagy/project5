using Business.Cache;
using DAL.Entities;
using DAL.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public static class SearchCriteriasManager
    {
        public static List<SearchCriteria> GetAll()
        {
            var criterias = MyCache.Instance.GetMyCachedItem(CacheConstants.CacheSearchCriteriaAll) as List<SearchCriteria>;

            if (criterias == null)
            {
                criterias = Kit.Instance.SearchCriterias.GetSearchCriteriaAll();
                criterias = criterias.OrderBy(o => o.DisplayOrder).ToList();
                for (int i = 0; i < criterias.Count; i++)
			    {
                    criterias[i].SearchCriteriaValues = criterias[i].SearchCriteriaValues.OrderBy(c => c.DisplayOrder).ToList();
                }

                MyCache.Instance.AddToMyCache(CacheConstants.CacheSearchCriteriaAll, criterias, MyCachePriority.Default);
            }

            return criterias;
        }
    }
}

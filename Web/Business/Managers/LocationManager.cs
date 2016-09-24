using DAL.Entities;
using DAL.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public static class LocationManager
    {
        public static List<County> GetAllCounties()
        {
            return Kit.Instance.Locations.GetCountiesAll();
        }
        public static List<County> GetCountiesLikeInput(string input)
        {
            var result = GetAllCounties();

            if (input != null)
            {
                result = result.Where(p => p.Name.ToLower().Contains(input.ToLower())).ToList();
            }

            return result;
        }
    }
}

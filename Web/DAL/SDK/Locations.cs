using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SDK
{
    public class Locations
    {
        private static ILocationRepository _repository;

        static Locations()
        {
            _repository = new Repository();
        }

        public List<County> GetCountiesAll()
        {
            return _repository.GetCountiesAll();
        }
    }
}

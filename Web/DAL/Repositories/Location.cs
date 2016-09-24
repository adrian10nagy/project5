using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ILocationRepository
    {
        List<County> GetCountiesAll();
    }

    public partial class Repository : ILocationRepository
    {
        public List<County> GetCountiesAll()
        {
            var counties = new List<County>();

            _dbRead.Execute(
                "CountiesGetAll",
            null,
                r => counties.Add(new County
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                }));

            return counties;
        }
    }
}

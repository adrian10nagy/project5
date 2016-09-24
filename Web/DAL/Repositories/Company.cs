using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanyAll();
    }

    public partial class Repository : ICompanyRepository
    {
        public List<Company> GetCompanyAll()
        {
            throw new NotImplementedException();

            var companies = new List<Company>();

            _dbRead.Execute(
                "CompanyGetAll",
            null,
                r => companies.Add(new Company
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                    // etc
                }));

            return companies;
        }
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanyAll();

        Company GetCompanyById(int id);

        void InsertCompany(Company company);

        void UpdateCompany(Company company);
    }

    public partial class Repository : ICompanyRepository
    {
        public List<Company> GetCompanyAll()
        {
            var companies = new List<Company>();

            _dbRead.Execute(
                "CompanyGetAll",
            null,
                r => companies.Add(new Company
                {
                    Id = Read<int>(r, "Id"),
                    Name = Read<string>(r, "Name"),
                    Id_County = Read<int>(r, "Id_cnt"),
                    Email = Read<string>(r, "Email"),
                    Phone = Read<string>(r, "Phone"),
                    Address = Read<string>(r, "Address"),
                    AddressXml = Read<XmlDocument>(r, "AddressXML")
                }));

            return companies;
        }

        public Company GetCompanyById(int id)
        {
            var company = new Company();

            _dbRead.Execute(
                "CompanyGetById",
            new[]
            {
                new SqlParameter("@id", id)
            },
            r => company = new Company
            {
                Id = Read<int>(r, "Id"),
                Name = Read<string>(r, "Name"),
                Id_County = Read<int>(r, "Id_cnt"),
                Email = Read<string>(r, "Email"),
                Phone = Read<string>(r, "Phone"),
                Address = Read<string>(r, "Address")
            });

            return company;
        }

        public void InsertCompany(Company company)
        {
            _dbRead.ExecuteNonQuery(
                "CompanyInsert",
            new[]
            {
                new SqlParameter("@name", company.Name),
                new SqlParameter("@phone", company.Phone),
                new SqlParameter("@email", company.Email),
                new SqlParameter("@joinDate", company.JoinDate),
                new SqlParameter("@Id_County", company.Id_County),
                new SqlParameter("@Address", company.Address),
                new SqlParameter("@AddressXML", company.AddressXml)
            });
        }

        public void UpdateCompany(Company company)
        {
            _dbRead.ExecuteNonQuery(
                "CompanyUpdate",
            new[]
            {
                new SqlParameter("@id", company.Id),
                new SqlParameter("@name", company.Name),
                new SqlParameter("@phone", company.Phone),
                new SqlParameter("@email", company.Email),
                new SqlParameter("@Id_County", company.Id_County),
                new SqlParameter("@joinDate", company.JoinDate),
                new SqlParameter("@Address", company.Address)
            });
        }

    }
}

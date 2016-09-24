using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ISearchCriteriaRepository
    {
        List<SearchCriteria> GetSearchCriteriaAll();
        List<SearchCriteriaValue> GetSearchCriteriaValuesById(int id);
    }

    public partial class Repository : ISearchCriteriaRepository
    {
        public List<SearchCriteria> GetSearchCriteriaAll()
        {
            var searchCriterias = new List<SearchCriteria>();

            _dbRead.Execute(
                "SearchCriteriaGetAll",
            null,
                r => searchCriterias.Add(new SearchCriteria
                {
                    Name = Read<string>(r, "name"),
                    Id = Read<int>(r, "id"),
                    NameToDisplay = Read<string>(r, "NameToDisplay"),
                    DisplayOrder = Read<int>(r, "DisplayOrder"),
                    CriteriaType = (CriteriaType)Read<int>(r, "ChoseType"),
                    SearchCriteriaValues = GetSearchCriteriaValuesById(Read<int>(r, "id"))
                }));

            return searchCriterias;
        }

        public List<SearchCriteriaValue> GetSearchCriteriaValuesById(int id)
        {
            var searchCriteriaValues = new List<SearchCriteriaValue>();

            _dbRead.Execute(
                "SearchCriteriaValuesGetAllById",
            new[] { 
                new SqlParameter("@Id_scr", id), 
            },
                r => searchCriteriaValues.Add(new SearchCriteriaValue
                {
                    Id = Read<int>(r, "id"),
                    Value = Read<string>(r, "Value"),
                    DisplayOrder = Read<int>(r, "DisplayOrder"),
                }));

            return searchCriteriaValues;
        }
    }
}

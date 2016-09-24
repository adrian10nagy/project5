
namespace DAL.Entities
{
    using System.Collections.Generic;

    public class SearchCriteria
    {
        public string Name { get; set; }
        public string NameToDisplay { get; set; }
        public CriteriaType CriteriaType { get; set; }
        public List<SearchCriteriaValue> SearchCriteriaValues { get; set; }

        public int Id { get; set; }
        public int DisplayOrder { get; set; }
    }

    public enum CriteriaType
    {
        RadioBox = 1,
        Checkbox = 2,
    }
}

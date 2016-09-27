using System;

namespace DAL.SDK
{
    public interface IKit : IDisposable
    {
        Users Users { get; }
        Products Products { get; }
        Offers Offers { get; }
        Orders Orders { get; }
        Locations Locations { get; }
        Companies Companies { get; }
        Categories Categories { get; }
        SearchCriterias SearchCriterias { get; }
    }

    public class Kit : IKit
    {
        private static Kit _instance = new Kit();
        public static Kit Instance { get { return _instance ?? getInstance(); } }

        static Kit getInstance()
        {
            return new Kit();
        }

        public Users Users { get { return new Users(); } }
        public Products Products { get { return new Products(); } }
        public Offers Offers { get { return new Offers(); } }
        public Orders Orders { get { return new Orders(); } }
        public Categories Categories { get { return new Categories(); } }
        public Companies Companies { get { return new Companies(); } }
        public Locations Locations { get { return new Locations(); } }
        public SearchCriterias SearchCriterias { get { return new SearchCriterias(); } }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}

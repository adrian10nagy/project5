
namespace DAL.Entities
{
    using System;
    using System.Xml;

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Id_County { get; set; }
        public string Address { get; set; }
        public string AddressXml { get; set; }
        public string AddressJSON { get; set; }
    }
}

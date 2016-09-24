
namespace DAL.Entities
{
    using System;

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string County { get; set; }
    }
}

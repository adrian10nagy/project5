using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Cart
    {
        public List<CartOffer> CartOffers { get; set; }
        public string EmailAddress { get; set; }
    }
}

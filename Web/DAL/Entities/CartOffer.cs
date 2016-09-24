using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CartOffer
    {
        public string SessionId { get; set; }
        public Offer Offer { get; set; }
        public int Quantity { get; set; }
    }
}

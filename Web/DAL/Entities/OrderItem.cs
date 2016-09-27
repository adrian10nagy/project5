using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderItem
    {
        public string SessionId { get; set; }
        public int Id { get; set; }
        public int OfferId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public OrderItemFlags OrderItemFlags { get; set; }
    }

    [Flags]
    public enum OrderItemFlags
    {
        IsApproved = 1
    }
}

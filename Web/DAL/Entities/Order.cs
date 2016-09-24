
namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public County County { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string DeliveryNotes { get; set; }
        public OrderFlags OrderFlags { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    [Flags]
    public enum OrderFlags
    {
        IsApproved = 1,
        IsBlocked = 2
    }
}

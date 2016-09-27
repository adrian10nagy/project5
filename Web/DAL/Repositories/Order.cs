using DAL.Entities;
namespace DAL.Repositories
{
    using System;
    using System.Data.SqlClient;

    public interface IOrderRepository
    {
        int InsertOrder(Order order);
        void InsertOrderItem(OrderItem orderItem, int orderId);
    }

    public partial class Repository : IOrderRepository
    {
        #region Insert

        public int InsertOrder(Order order)
        {
            int oderId = 0;
            _dbRead.Execute(
                "OrderInsert",
            new[] { 
                new SqlParameter("@i_Address", order.Address), 
                new SqlParameter("@i_City", order.City), 
                new SqlParameter("@i_County", order.County.Id), 
                new SqlParameter("@i_DeliveryNotes", order.DeliveryNotes), 
                new SqlParameter("@i_OrderFlags", (int)order.OrderFlags), 
                new SqlParameter("@i_userId", order.User.Id), 
                new SqlParameter("@i_created", DateTime.Now), 
            },
                r =>
                oderId = Read<int>(r, "Id")
            );

            return oderId;
        }

        public void InsertOrderItem(OrderItem orderItem, int orderId)
        {
            _dbRead.Execute(
                "OrderItemInsert",
            new[] { 
                new SqlParameter("@i_orderId", orderId), 
                new SqlParameter("@i_offerId", orderItem.OfferId), 
                new SqlParameter("@i_flags", (int)orderItem.OrderItemFlags), 
                new SqlParameter("@i_price", orderItem.Price), 
                new SqlParameter("@i_Quantity", orderItem.Quantity), 
            });

        }

        #endregion
    }
}

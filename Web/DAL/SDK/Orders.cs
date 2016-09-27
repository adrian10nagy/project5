namespace DAL.SDK
{
    using DAL.Entities;
    using DAL.Repositories;

    public class Orders
    {
        private static IOrderRepository _repository;

        static Orders()
        {
            _repository = new Repository();
        }

        #region Insert

        public int Insert(Order order)
        {
            var orderId = _repository.InsertOrder(order);

            foreach (var orderItem in order.OrderItems)
            {
                Insert(orderItem, orderId);
            }

            return orderId;
        }

        private void Insert(OrderItem orderItem, int orderId)
        {
            _repository.InsertOrderItem(orderItem, orderId);
        }

        #endregion
    }
}

namespace Business.Managers
{
    using DAL.Entities;
    using DAL.SDK;

    public static class OrderManager
    {
        public static int Add(Order order)
        {
            var orderId = Kit.Instance.Orders.Insert(order);

            return orderId;
        }

    }
}

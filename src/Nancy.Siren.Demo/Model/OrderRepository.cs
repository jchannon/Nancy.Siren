namespace Nancy.Siren.Demo.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrderRepository : IOrderRepository
    {
        private IEnumerable<Order> orders = new[] { new Order { ItemCount = 2, OrderNumber = 45323, Status = "Pending" }, new Order { ItemCount = 5, OrderNumber = 6534, Status = "Completed" } };

        public IEnumerable<Order> GetAll()
        {
            return orders;
        }

        public Order GetById(int id)
        {
            return orders.FirstOrDefault(x => x.OrderNumber == id);
        }
    }
}

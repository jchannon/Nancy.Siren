namespace Nancy.Siren.Demo.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrderRepository : IOrderRepository
    {


        private static Dictionary<int, List<OrderItem>> orderItems = new Dictionary<int, List<OrderItem>>
        {
            {45323, new List<OrderItem>(new []{new OrderItem{ProductCode = "QW123", Quantity = 2}, new OrderItem{ProductCode = "CXP433", Quantity = 1}})},
            {6534, new List<OrderItem>(new []{new OrderItem{ProductCode = "PL645", Quantity = 1}, new OrderItem{ProductCode = "ZZ555", Quantity = 5}})}
        };

        private static List<Order> orders =
           new List<Order>(new[]
            {
                new Order {OrderNumber = 45323, Status = "Pending"},
                new Order {OrderNumber = 6534, Status = "Completed"}
            });

        public IEnumerable<Order> GetAll()
        {
            return orders;
        }

        public Order GetById(int id)
        {
            var order = orders.SingleOrDefault(x => x.OrderNumber == id);
            if (order != null)
            {
                order.ItemCount = orderItems[id].Sum(x => x.Quantity);
                return order;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var order = orders.SingleOrDefault(x => x.OrderNumber == id);
            if (order != null)
            {
                orders.Remove(order);
                return true;
            }
            return false;
        }

        public IEnumerable<OrderItemViewModel> GetItemsForOrder(int id)
        {
            //This is hacky but just an example
            if (orderItems.ContainsKey(id))
            {
                var items = orderItems[id];

                return items.Select(orderItem => new OrderItemViewModel
                {
                    ProductCode = orderItem.ProductCode,
                    Quantity = orderItem.Quantity,
                    ProductName = "Lovely product name that should be returned from a DB Lookup",
                    ProductUrl = "http://amazon.com",
                    OrderNumber = id
                });
            }

            return Enumerable.Empty<OrderItemViewModel>();
        }

        public bool AddItemsToOrder(int id, List<OrderItem> model)
        {
            if (orderItems.ContainsKey(id))
            {
                var items = orderItems[id];

                foreach (var orderItem in model)
                {
                    var item = items.SingleOrDefault(x => x.ProductCode == orderItem.ProductCode);
                    if (item != null)
                    {
                        item.Quantity += orderItem.Quantity;
                    }
                    else
                    {
                        items.Add(orderItem);
                    }
                }

                return true;
            }
            return false;
        }
    }
}

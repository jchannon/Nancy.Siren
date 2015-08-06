namespace Nancy.Siren.Demo.Model
{
    using System.Collections.Generic;

    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        bool Delete(int id);
        IEnumerable<OrderItemViewModel> GetItemsForOrder(int id);
        bool AddItemsToOrder(int id, List<OrderItem> model);
    }
}

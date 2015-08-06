namespace Nancy.Siren.Demo.Model
{
    using System.Collections.Generic;

    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Delete(int id);
    }
}

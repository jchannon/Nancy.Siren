namespace Nancy.Siren.Demo
{
    using Nancy.Siren.Demo.Model;

    public class HomeModule : NancyModule
    {
        public HomeModule(IOrderRepository orderRepository)
        {
            Get["/"] = _ =>
                {
                    var orders = orderRepository.GetAll();
                    return orders;
                };
        }
    }
}

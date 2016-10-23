namespace Nancy.Siren.Demo
{
    using System.Collections.Generic;
    using System.Linq;

    using Nancy.ModelBinding;
    using Nancy.Siren.Demo.Model;

    public class OrdersModule : NancyModule
    {
        public OrdersModule (IOrderRepository orderRepository)
            : base ("/orders")
        {
            Get ("/" , _ =>
             {
                 var orders = orderRepository.GetAll ();
                 return orders;
             });

            Post ("/", _ => Response.AsCreatedResource (911));

            Post ("/{id:int}", parameters =>
             {
                 var model = this.Bind<List<OrderItem>> ();

                 int id = parameters.id;
                 var result = orderRepository.AddItemsToOrder (id, model);
                 return result ? HttpStatusCode.Created : HttpStatusCode.NotFound; //loc header
            });

            Get ("/{id:int}", parameters =>
             {
                 int id = parameters.id;

                 var order = orderRepository.GetById (id);
                 if (order == null)
                 {
                     return HttpStatusCode.NotFound;
                 }

                 return order;
             });

            Get ("/{id:int}/items", parameters =>
             {
                 int id = parameters.id;

                 var items = orderRepository.GetItemsForOrder (id);

                 return items;
             });

            Delete ("/{id:int}", parameters =>
             {
                 int id = parameters.id;

                 var result = orderRepository.Delete (id);

                 return result ? HttpStatusCode.NoContent : HttpStatusCode.NotFound;
             });
        }
    }
}
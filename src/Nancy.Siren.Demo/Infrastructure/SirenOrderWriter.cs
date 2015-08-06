namespace Nancy.Siren.Demo.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Dynamic;

    using Nancy.Siren;
    using Nancy.Siren.Demo.Model;

    using Action = Nancy.Siren.Action;

    public class SirenOrderWriter : ISirenDocumentWriter<Order>
    {
        public Siren Write(IEnumerable<Order> data, Uri uri)
        {
            var sirenDoc = new Siren
            {
                @class = new[] { "collection" },
                entities = new List<Entity>()
            };

            foreach (var order in data)
            {
                var entity = new Entity
                {
                    @class = new[] { "order" },
                    href = uri + "orders/" + order.OrderNumber,
                    rel = new[] { uri + "rels/order" },
                    properties = order
                };

                sirenDoc.entities.Add(entity);
            }
            sirenDoc.actions = new List<Action>(new[]{
            
                new Action
                {
                    name = "add-order",
                    title = "Add Order",
                    method = "POST",
                    href = uri + "/orders/",
                    type = "application/json",
                    fields = new List<Field>(new[] {new Field {name = "orderitems", type = "array" }})
                }
            });
            sirenDoc.links = new List<Link> { new Link { href = uri + "orders/", rel = new[] { "self" } } };

            return sirenDoc;
        }

        public Siren Write(Order data, System.Uri uri)
        {
            throw new System.NotImplementedException();

            /*
              new Action
                {
                    name = "add-to-order",
                    title = "Add Item To Order",
                    method = "POST",
                    href = uri + "/orders/",
                    type = "application/json",
                    fields = new List<Field>(new[] {new Field {name = "ordernumber", type = "number" }, new Field{name = "productCode"}})
                }
             */
        }
    }
}

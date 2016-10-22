namespace Nancy.Siren.Demo.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy.Siren.Demo.Model;

    using Action = Nancy.Siren.Action;

    public class OrderWriter : ISirenDocumentWriter<Order>
    {
        public Siren Write (IEnumerable<Order> data, Uri uri)
        {
            var sirenDoc = new Siren
            {
                @class = new [] { "collection" },
                entities = new List<Entity> (),
                properties = new {Count = data.Count()}
            };

            foreach (var order in data)
            {
                var entity = new Entity
                {
                    @class = new [] { "order" },
                    rel = new [] { "item" },
                    properties = order,
                    links = new List<Link> { new Link { href = uri + "/" + order.OrderNumber, rel = new [] { "self" } } }
                };

                sirenDoc.entities.Add (entity);
            }

            sirenDoc.actions = new List<Action> (new []{

                new Action
                {
                    name = "add-order",
                    title = "Add Order",
                    method = "POST",
                    href = uri.ToString(),
                    type = "application/json",
                    fields = new List<Field>(new[] {new Field {name = "productCode", type = "text"}, new Field{name = "quantity", type = "number"}})
                }
            });

            sirenDoc.links = new List<Link> { new Link { href = uri.ToString(), rel = new [] { "self" } } };

            return sirenDoc;
        }

        public Siren Write (Order data, Uri uri)
        {
            var sirenDoc = new Siren
            {
                @class = new [] { "order" },
                properties = data,
                entities =
                    new List<Entity>
                    {
                        new Entity
                        {
                            @class = new[] {"collection"},
                            rel =
                                new[]
                                {
                                    uri.Scheme + "://" + uri.DnsSafeHost + ":" +
                                    (uri.Port != 80 ? uri.Port.ToString() : "") + "/rels/order-items"
                                },
                            href = uri + "/items"
                        }
                    },
                actions =
                    new List<Action> (new []
                    {
                        new Action
                        {
                            name = "delete-order",
                            title = "Delete Order",
                            href = uri.ToString(),
                            method = "DELETE"
                        },
                        new Action
                        {
                            name = "add-to-order",
                            title = "Add Item To Order",
                            method = "POST",
                            href = uri.ToString(),
                            type = "application/json",
                            fields =
                                new List<Field>(new[]
                                {
                                    new Field {name = "productCode", type = "text"},
                                    new Field {name = "quantity", type = "number"}
                                })
                        }
                    })
            };

            sirenDoc.links = new List<Link> (new [] { new Link { rel = new [] { "self" }, href = uri.ToString () } });

            return sirenDoc;
        }
    }
}

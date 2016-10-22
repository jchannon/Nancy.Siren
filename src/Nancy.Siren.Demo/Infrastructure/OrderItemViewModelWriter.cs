namespace Nancy.Siren.Demo.Infrastructure
{
    using System;
    using System.Collections.Generic;

    using Nancy.Siren.Demo.Model;

    using Action = Nancy.Siren.Action;

    public class OrderItemViewModelWriter : ISirenDocumentWriter<OrderItemViewModel>
    {
        public Siren Write(IEnumerable<OrderItemViewModel> data, Uri uri)
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
                    @class = new[] { "order-item" },
                    rel = new[] { uri.Scheme + "://" + uri.DnsSafeHost + ":" +
                                    (uri.Port != 80 ? uri.Port.ToString() : "") + "/rels/orderitem" },
                    href=uri.ToString(),
                    properties = order
                };

                sirenDoc.entities.Add(entity);
            }

           

            sirenDoc.links = new List<Link> { new Link { href = uri.ToString() , rel = new[] { "self" } }, new Link{href = uri.ToString().Replace("/items",""), rel = new []{"order"}} };  

            return sirenDoc;
        }

        public Siren Write(OrderItemViewModel data, Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}

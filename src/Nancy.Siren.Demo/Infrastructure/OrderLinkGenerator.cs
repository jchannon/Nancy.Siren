namespace Nancy.Siren.Demo.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Nancy.Siren;
    using Nancy.Siren.Demo.Model;

    public class OrderLinkGenerator : ILinkGenerator
    {
        private ISirenDocumentWriter<Order> writer;

        public OrderLinkGenerator(ISirenDocumentWriter<Order> writer)
        {
            this.writer = writer;
        }

        public bool CanHandle(Type model)
        {
            var expectedType = typeof(IEnumerable<Order>);

            if (expectedType.IsAssignableFrom(model))
            {
                return true;
            }

            if (model == typeof(Order))
            {
                return true;
            }

            return false;
        }

        public Siren Handle(object model, Uri uri)
        {
            var modeldata = model as IEnumerable<Order>;
            if (modeldata == null)
            {
                var oneFriend = (Order)model;
                var sirenDoc = writer.Write(oneFriend, uri);
                return sirenDoc;
            }

            var sirenDocWithItems = writer.Write(modeldata, uri);
            return sirenDocWithItems;
        }
    }
}

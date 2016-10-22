namespace Nancy.Siren.Demo
{
    using System;
    using Nancy.Bootstrapper;
    using Nancy.Responses.Negotiation;
    using Nancy.Siren.Demo.Infrastructure;
    using Nancy.Siren.Demo.Model;
    using Nancy.TinyIoc;
    using ServiceStack.Text;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            JsConfig.IncludeNullValues = false;
            JsConfig.ExcludeTypeInfo = true;
            JsConfig.EmitCamelCaseNames = true;
        }
        protected override void ConfigureApplicationContainer(TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ISirenDocumentWriter<Order>, OrderWriter>();
            container.Register<ISirenDocumentWriter<OrderItemViewModel>, OrderItemViewModelWriter>();

            container.RegisterMultiple<ILinkGenerator>(new[] { typeof(OrderLinkGenerator) });
        }

        protected override Func<ITypeCatalog, NancyInternalConfiguration> InternalConfiguration
        {
            get
            {
                var processors = new[]
                {
                    typeof(JsonProcessor),
                    typeof(SirenResponseProcessor)
                };

                return NancyInternalConfiguration.WithOverrides(x => x.ResponseProcessors = processors);
            }
        }
    }
}

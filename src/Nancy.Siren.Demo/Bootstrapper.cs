namespace Nancy.Siren.Demo
{
    using Nancy.Siren.Demo.Infrastructure;
    using Nancy.Siren.Demo.Model;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ISirenDocumentWriter<Order>, OrderWriter>();
            container.RegisterMultiple<ILinkGenerator>(new[] { typeof(OrderLinkGenerator) });
        }

    }
}

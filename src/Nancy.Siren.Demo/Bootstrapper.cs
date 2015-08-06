namespace Nancy.Siren.Demo
{
    using Nancy.Siren.Demo.Infrastructure;
    using Nancy.Siren.Demo.Model;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ISirenDocumentWriter<Order>, SirenOrderWriter>();
            container.RegisterMultiple<ILinkGenerator>(new[] { typeof(OrderLinkGenerator) });
        }

    }
}

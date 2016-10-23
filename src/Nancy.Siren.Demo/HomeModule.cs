namespace Nancy.Siren.Demo
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => new { Orders = this.Context.Request.Url + "/orders" });
        }
    }
}

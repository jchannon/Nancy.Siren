namespace Nancy.Siren.Demo
{
    using global::Owin;    

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}

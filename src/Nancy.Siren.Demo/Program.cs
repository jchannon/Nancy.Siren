namespace Nancy.Siren.Demo
{
    using Microsoft.AspNetCore.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://+:8080")
                .Build();
            
            host.Run();
        }
    }
}

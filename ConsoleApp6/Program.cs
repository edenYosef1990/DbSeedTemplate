using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var host = Host.CreateDefaultBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices((context, services) =>
                {
                    var connectionStr = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=MyDb";
                    services.AddDbContext<MyDbContext>(builder => builder.UseSqlServer(connectionStr));
                }).Build();

            var context = host.Services.GetRequiredService<MyDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
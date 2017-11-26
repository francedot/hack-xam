using System.IO;
using EyeCare.Backend.Training.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace EyeCare.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(servicesCollection =>
                {
                    servicesCollection.AddScoped<IFileProvider>(provider => 
                        new PhysicalFileProvider(Directory.GetCurrentDirectory()));
                    servicesCollection.AddSingleton<EyesTrainer>();
                })
                .UseStartup<Startup>()
                .Build();
    }
}

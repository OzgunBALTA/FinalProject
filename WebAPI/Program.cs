using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //Server�n yay�nla ilgili durumlar�n oldu�u k�s�m.
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //.Net Core IOC'sini kullanma servis sa�lay�c� olarak Autofac kullan dedik.
                .ConfigureContainer<ContainerBuilder>(builder=> 
                {
                    builder.RegisterModule(new AutofacBusinessModule()); //AutofactBusinessModule kodlar�n� �al��t�aca��m�z� belirttik.
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

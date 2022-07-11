using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        //IServiceColection ASP.Net (API) uygulamamızın servis bağımlılıklarını
        //ekledğimiz ya da araya girmesini istediğimiz servislerin koleksiyonudur. -DependenceResolvers-
        //Polimorfizm yapıyoruz. İleride CoreModule haricinde başka ICoreModuller gelirse hepsini tek seferde yükleyecek.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}

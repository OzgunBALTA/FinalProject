using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool 
        //Her bir interface'in serviceteki karşılığını alabiliriz. Dependency injection yapabilmemizi sağlar.
        //Bu metodu kullanarak Autofac'te yaptığımız injection'ı her platforma taşıyabiliriz(Windows Form, WebApi gibi)
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}

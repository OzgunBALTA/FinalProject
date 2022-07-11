using Core.CrossCuttingConcers.Caching.Abstract;
using Core.CrossCuttingConcers.Caching.Concrete.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //Bağımlılık zincirinde olmayanları (CrossCuttingConcers) enjekte etmek için buraya yazıyoruz.
        public void Load(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddMemoryCache(); //Bu Microsoftun kendi enjektesi Bunu yazdığımızda MemoryCache'i enjekte ediyo. Addsinleton yazmamızın sebebi ileride redis kullanırsak diye. Redise geçersen bunu sil.
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //Redis kullanırsak burayı RedisCacheManager olarak revize etmemiz yeterli
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//Tüm arayüzlerde jwt çalıştırabilmek için newleme yapmayı buraya yazdık.
            serviceCollection.AddSingleton<Stopwatch>(); //PerformanceAspect için 
        }
    }
}

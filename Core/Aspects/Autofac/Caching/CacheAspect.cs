using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Caching.Abstract;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception //Kendisi bi attribute (MethodInterception)
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //Süre vermezsek 60dk boyunca Cache'te duracak
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //Redise geçsen de değiştirme buraya zaten otomatik gelecek. Interface
        }

        public override void Intercept(IInvocation invocation)
        {
            //Önce key oluştur. Eğer Cache varsa getir. Yoksa metodu çalıştır. Cache'e ekle.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //invocation.Method.ReflectedType.FullName: Namespace+Class ismi, invocation.Method.Name: Metodun ismi ; Key oluşturuyoruz.
            //Örnek: Northwind.Business.IProductService.GetAll
            var arguments = invocation.Arguments.ToList();
            //Metodun varsa parametrelerini listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Metodun parametre değeri varsa içine ekle. GetAll(parametreler)
            if (_cacheManager.IsAdd(key)) //Daha önceden bellekte böyle bir Cache anahtarı var mı
            {
                invocation.ReturnValue = _cacheManager.Get(key); 
                //invocation.ReturnValue: Varsa metodu çalıştırmadan geri dön Cache'den getir.
                return;
            }
            invocation.Proceed(); // Yosa metodu çalıştır. Veritabanından veriyi getir.
            _cacheManager.Add(key, invocation.ReturnValue, _duration); // veriyi Cache'e ekle.
        }
    }
}

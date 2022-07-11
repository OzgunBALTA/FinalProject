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
    //Veriyi manipüle eden metotlara eklenir. Yeni veri eklenirse, ver silinir ya da güncellenirse eski Cache'i sil.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation) 
            //Metot başarılı olursa çalıştır. Örneğin veri eklenememişse boşuna Cache'i silme
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}

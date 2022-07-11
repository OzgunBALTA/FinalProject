using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch; //Stopwatch: Kronometre

        public PerformanceAspect(int interval) //interval: kaç saniyeyi geçerse uyarı versin
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start(); //Metot çalışmaya başladığında kronometreyi çalıştır.
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                //Eğer metodun çalışması verdiğim süreyi aşarsa console'a logla. Başla yere de loglayabiliriz.
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset(); //Metot bitince kronometreyi resetle.
        }
    }
}

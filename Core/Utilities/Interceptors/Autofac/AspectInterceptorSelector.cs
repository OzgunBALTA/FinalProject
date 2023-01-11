using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors.Autofac
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //Her Class veya Metot için ilgili Attribute'leri kontrol ediyoruz. Bunları listeliyoruz. Var mı yok mu bakıyoruz.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList(); // Git Class'ın Attribute'lerini oku listele
            var methodAttributes = type.GetMethod(method.Name) 
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true); //Git Metod'un Attribute'lerini oku
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new PerformanceAspect(5));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}


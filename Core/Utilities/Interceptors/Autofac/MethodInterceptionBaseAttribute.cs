using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors.Autofac
{
    //Base Attribute sınıfı oluşturuyoruz.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //Class'lar için ve Metotlar için kullanılır. Birden fazla işlem için kullanılabilir. Inherite etmiş yer de çalışır.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}


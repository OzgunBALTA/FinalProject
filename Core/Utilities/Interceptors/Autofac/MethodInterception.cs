using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors.Autofac
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // <Attributeleri çalıştırıyoruz.
        // invocation = çalıştırmak istediğimiz metot
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); // Metot çalışmadan önce,
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); // Metotta hata olursa,
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //  Metot başarılı olduğunda,
                }
            }
            OnAfter(invocation); // Metottan sonra çalışmasını istersek burayı çalıştıracağız.
        }
    }
}

